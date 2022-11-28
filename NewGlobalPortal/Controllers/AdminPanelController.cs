using NewGlobalPortal.Models;
using NewGlobalPortal.Models.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NewGlobalPortal.Controllers
{
    public class AdminPanelController : Controller
    {
        UyumsoftApi api = new UyumsoftApi();
        
        // GET: AdminPanel
        public ActionResult Index()
        {
            Yetkiler yetki = new Yetkiler();
            if (yetki.kullanici.LOGICALREF == 0)
            {
                SessionsInfo oturum = new SessionsInfo();
                oturum.oturumTanimla();
            }
            if (yetki.kullanici.PortalAdmini==true)
            {
                return RedirectToAction("Index","PortalAdmin");
            }
            else
            {
               
                ViewBag.AdminMi = yetki.kullanici.AdminMi;
                ViewBag.PortalAdmini = yetki.kullanici.PortalAdmini;
                return View();
            }
            
        }

        [HttpPost]
        public string KullanicilariGetir()
        {
            Yetkiler yetki = new Yetkiler();
            var db = new Models.NewGlobalDBEntities();
            var query = (from a in db.Kullanicilars
                         join x in db.KullaniciYetkileris on a.LOGICALREF equals x.KullaniciId
                         where a.YetkiliOlduguCariIdleri == yetki.kullanici.YetkiliOlduguCariIdleri && a.KullaniciAdi != yetki.kullanici.KullaniciAdi && a.PortalAdmini !=true
                         select new { a, x }).ToList();

            return JsonConvert.SerializeObject(query);


        }
        [HttpPost]
        public string TumKullanicilariGetir()
        {
            Yetkiler yetki = new Yetkiler();
            var db = new Models.NewGlobalDBEntities();
            var query = (from a in db.Kullanicilars
                         join x in db.KullaniciYetkileris on a.LOGICALREF equals x.KullaniciId
                         where a.KullaniciAdi != yetki.kullanici.KullaniciAdi && a.PortalAdmini==false
                         select new { a, x }).ToList();

            return JsonConvert.SerializeObject(query);


        }

        [HttpPost]
        public string yetkileriEkleGuncelle(string aktif, string kullaniciAdi, string adiSoyadi, string mailAdresi, string gsm, string sipraisOlusturabilir, string siparisleriGorebilir, string irsaliyeleriGorebilir, string hesapEkstresiGorebilir)
        {
            Yetkiler yetki = new Yetkiler();
            var result = new RestSharp.RestResponse();
            var db = new Models.NewGlobalDBEntities();
            var tns = db.Database.BeginTransaction();
            int sayi = 0;
            Random rastgele = new Random();
            try
            {
                var kullanicilar = db.Kullanicilars.Where(x => x.KullaniciAdi == kullaniciAdi).FirstOrDefault();
                if (kullanicilar == null)
                {
                    
                 
                    kullanicilar = new Models.Kullanicilar();
                    kullanicilar.AdiSoyadi = adiSoyadi;
                    kullanicilar.AdminMi = false;
                    kullanicilar.EnSonSifreDegistirmeTarihi = DateTime.Now.AddYears(-2);
                    kullanicilar.Gsm = gsm;
                    kullanicilar.KullaniciAdi = kullaniciAdi;
                    kullanicilar.MailAdresi = mailAdresi;
                    kullanicilar.Statu = Convert.ToBoolean(aktif);
                    sayi= rastgele.Next(100000, 999999);
                    kullanicilar.AktivasyonSifresi = sayi.ToString();
                    kullanicilar.YetkiliOlduguCariIdleri = yetki.kullanici.YetkiliOlduguCariIdleri;
                    db.Kullanicilars.Add(kullanicilar);
                    db.SaveChanges();
                }
                else
                {
                    if (kullanicilar.YetkiliOlduguCariIdleri==yetki.kullanici.YetkiliOlduguCariIdleri)
                    {
                        kullanicilar.AdiSoyadi = adiSoyadi;
                        kullanicilar.Gsm = gsm;
                        kullanicilar.MailAdresi = mailAdresi;
                        kullanicilar.Statu = Convert.ToBoolean(aktif);
                        db.SaveChanges();
                    }
                    else
                    {
                        tns.Rollback();
                        result.IsSuccessful = false;
                        result.Content = "Bu Kullanıcıyı Güncelleme Yetkiniz Yoktur.";
                        return JsonConvert.SerializeObject(result);
                    }
                   
                }
                var yetkiler = db.KullaniciYetkileris.Where(x => x.KullaniciId == kullanicilar.LOGICALREF).FirstOrDefault();
                if (yetkiler == null)
                {
                    yetkiler = new Models.KullaniciYetkileri();
                    yetkiler.HesapEkstresiniGorebilirMi = Convert.ToBoolean(hesapEkstresiGorebilir);
                    yetkiler.IrsaliyeleriGorebilirMi = Convert.ToBoolean(irsaliyeleriGorebilir);
                    yetkiler.KullaniciId = kullanicilar.LOGICALREF;
                    yetkiler.SiparisleriGorebilirMi = Convert.ToBoolean(siparisleriGorebilir);
                    yetkiler.SiparisOluturabilirMi = Convert.ToBoolean(sipraisOlusturabilir);
                    db.KullaniciYetkileris.Add(yetkiler);
                    db.SaveChanges();
                }
                else
                {
                    yetkiler.HesapEkstresiniGorebilirMi = Convert.ToBoolean(hesapEkstresiGorebilir);
                    yetkiler.IrsaliyeleriGorebilirMi = Convert.ToBoolean(irsaliyeleriGorebilir);
                    yetkiler.SiparisleriGorebilirMi = Convert.ToBoolean(siparisleriGorebilir);
                    yetkiler.SiparisOluturabilirMi = Convert.ToBoolean(sipraisOlusturabilir);
                    db.SaveChanges();
                }
                result.IsSuccessful = true;
                result.Content = "Kayıt Başarılı";
                if (sayi!=0)
                {
                  
                    MailIslemleri mail = new MailIslemleri();
                    mail.EksizMailGonderme("", mailAdresi, "Aktivasyon", "Sisteme üyeliğiniz gerçekleşmiştir. <br/>"+
                        "Sistem Linki:<b>https://bayi.newglobalinsaat.com/</b><br/>Kullanıcı Adı:<b>" + kullaniciAdi+"</b><br/>Şifre:<b>" + sayi+"</b><br/>Bilgileri İle Sisteme Giriş Yapabilirsiniz.");

                }

                tns.Commit();
            }
            catch (Exception hata)
            {
                tns.Rollback();
                result.IsSuccessful = false;
                result.Content = "İşlem Tamamlanamadı.Hata:" + hata.Message;

            }

            return JsonConvert.SerializeObject(result);


        }



        [HttpPost]
        public string sifreDegistir(string eskiSifre, string yeniSifre, string yeniSifreTekrar)
        {
            Yetkiler yetki = new Yetkiler();
            var result = new RestSharp.RestResponse();
            string md5Sifre = MD5Hashh.MD5Sifrele(eskiSifre);
            var db = new Models.NewGlobalDBEntities();
            var kullanici = db.Kullanicilars.Where(x => x.LOGICALREF == yetki.kullanici.LOGICALREF && x.Sifre == md5Sifre).FirstOrDefault();
            if (kullanici == null)
            {
                result.IsSuccessful = false;
                result.Content = "Eski Şifre Hatalı.";
            }
            else
            {
                if (sifreUygunMu(yeniSifre, yeniSifreTekrar) == "OK")
                {
                    kullanici.Sifre = MD5Hashh.MD5Sifrele(yeniSifre);
                    kullanici.EnSonSifreDegistirmeTarihi = DateTime.Now;
                    db.SaveChanges();
                    result.IsSuccessful = true;
                    result.Content = "Şifre Başarıyla Değiştirildi.";
                }
                else
                {
                    result.IsSuccessful = false;
                    result.Content = sifreUygunMu(yeniSifre, yeniSifreTekrar);
                }

            }
            return JsonConvert.SerializeObject(result);


        }

        public string sifreUygunMu(string sifre, string sifreTekrar)
        {
            if (sifre == sifreTekrar)
            {
                if (sifre.Length >= 6 && sifre.Length <= 10)
                {
                    if (!sifre.Contains(" "))
                    {
                        return "OK";
                    }
                    else
                    {
                        return "Şifre boşluk karakteri içeremez.";
                    }
                }
                else
                {
                    return "Şifre uzunluğu 6 ile 10 karakter arasında olmalıdır.";
                }
            }
            else
            {
                return "Yeni şifreler birbiriyle aynı değil.";
            }

        }


        [HttpPost]
        public string carileriGetir()
        {
            return api.Cariler();
        }




        [HttpPost]
        public string yeniAdminEkle(string cariID, string aktif, string kullaniciAdi, string adiSoyadi, string mailAdresi, string gsm)
        {
            var result = new RestSharp.RestResponse();
            var db = new Models.NewGlobalDBEntities();
            var tns = db.Database.BeginTransaction();
            try
            {
                var kullanicilar = db.Kullanicilars.Where(x => x.KullaniciAdi == kullaniciAdi).FirstOrDefault();
                if (kullanicilar == null)
                {
                    kullanicilar = new Models.Kullanicilar();
                    kullanicilar.AdiSoyadi = adiSoyadi;
                    kullanicilar.AdminMi = true;
                    kullanicilar.EnSonSifreDegistirmeTarihi = DateTime.Now.AddYears(-2);
                    kullanicilar.Gsm = gsm;
                    kullanicilar.KullaniciAdi = kullaniciAdi;
                    kullanicilar.MailAdresi = mailAdresi;
                    kullanicilar.Statu = Convert.ToBoolean(aktif);
                    kullanicilar.YetkiliOlduguCariIdleri = cariID;
                    db.Kullanicilars.Add(kullanicilar);
                    db.SaveChanges();
                }
                else
                {
                    kullanicilar.AdiSoyadi = adiSoyadi;
                    kullanicilar.Gsm = gsm;
                    kullanicilar.MailAdresi = mailAdresi;
                    kullanicilar.Statu = Convert.ToBoolean(aktif);
                    db.SaveChanges();
                }
                var yetkiler = db.KullaniciYetkileris.Where(x => x.KullaniciId == kullanicilar.LOGICALREF).FirstOrDefault();
                if (yetkiler == null)
                {
                    yetkiler = new Models.KullaniciYetkileri();
                    yetkiler.HesapEkstresiniGorebilirMi = true;
                    yetkiler.IrsaliyeleriGorebilirMi = true;
                    yetkiler.KullaniciId = kullanicilar.LOGICALREF;
                    yetkiler.SiparisleriGorebilirMi = true;
                    yetkiler.SiparisOluturabilirMi = true;
                    db.KullaniciYetkileris.Add(yetkiler);
                    db.SaveChanges();
                }
                else
                {
                    yetkiler.HesapEkstresiniGorebilirMi = true;
                    yetkiler.IrsaliyeleriGorebilirMi = true;
                    yetkiler.SiparisleriGorebilirMi = true;
                    yetkiler.SiparisOluturabilirMi = true;
                    db.SaveChanges();
                }
                result.IsSuccessful = true;
                result.Content = "Kayıt Başarılı";
                tns.Commit();
            }
            catch (Exception hata)
            {
                tns.Rollback();
                result.IsSuccessful = false;
                result.Content = "İşlem Tamamlanamadı.Hata:" + hata.Message;

            }

            return JsonConvert.SerializeObject(result);


        }


    }
}