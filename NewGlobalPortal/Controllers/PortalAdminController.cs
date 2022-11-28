using NewGlobalPortal.Models;
using NewGlobalPortal.Models.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGlobalPortal.Controllers
{
    public class PortalAdminController : Controller
    {
        
        UyumsoftApi api = new UyumsoftApi();
        // GET: PortalAdmin
        public ActionResult Index()
        {
            Yetkiler yetki = new Yetkiler();
            if (yetki.kullanici.PortalAdmini == true)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index", "AdminPanel");
            }

        }

        [HttpPost]
        public string CarileriGetir()
        {
            return api.Cariler();
        }

        [HttpPost]
        public string kullanicilar()
        {
            Yetkiler yetki = new Yetkiler();
            var db = new Models.NewGlobalDBEntities();
            var query = db.Kullanicilars.Where(x => x.LOGICALREF != yetki.kullanici.LOGICALREF && x.PortalAdmini!=true).OrderBy(x => x.KullaniciAdi);
            return JsonConvert.SerializeObject(query);
        }

        [HttpPost]
        public string adminEkle(string cariAdi, string cariId, string kullaniciAdi, string adiSoyadi, string mailAdresi, string gsm)
        {
            var result = new RestSharp.RestResponse();
            var db = new Models.NewGlobalDBEntities();
            var query = db.Kullanicilars.Where(x => x.KullaniciAdi == kullaniciAdi).FirstOrDefault();
            int sayi = 0;
            Random rastgele = new Random();
            if (query == null)
            {
                query = new Kullanicilar();
                query.AdiSoyadi = adiSoyadi;
                query.AdminMi = true;
                query.Gsm = gsm;
                query.KullaniciAdi = kullaniciAdi;
                query.MailAdresi = mailAdresi;
                query.EnSonSifreDegistirmeTarihi = DateTime.Now.AddYears(-2);
                query.PortalAdmini = false;
                query.Statu = true;
                sayi = rastgele.Next(100000, 999999);
                query.AktivasyonSifresi = sayi.ToString();
                query.YetkiliOlduguCariIdleri = cariId;
                query.YetkiliOlduguCariAdi = cariAdi;
                db.Kullanicilars.Add(query);
                db.SaveChanges();
                var yetki = new KullaniciYetkileri();
                yetki.HesapEkstresiniGorebilirMi = true;
                yetki.IrsaliyeleriGorebilirMi = true;
                yetki.KullaniciId = query.LOGICALREF;
                yetki.SiparisleriGorebilirMi = true;
                yetki.SiparisOluturabilirMi = true;
                db.KullaniciYetkileris.Add(yetki);
                db.SaveChanges();
                result.IsSuccessful = true;
                result.Content = "Kullanıcı Sisteme Eklendi.";
                var activation = new ActivationInfo();
                activation.AdiSoyadi = adiSoyadi;
                activation.KullaniciAdi = kullaniciAdi;
                activation.SonGecerlilikTarihi = DateTime.Now.AddHours(2).ToString();
                var temp = Aes256CbcEncrypter.Encrypt(JsonConvert.SerializeObject(activation));
                MailIslemleri mail = new MailIslemleri();
                mail.EksizMailGonderme("", mailAdresi, "Aktivasyon", "Sisteme üyeliğiniz gerçekleşmiştir. <br/>" +
                       "Sistem Linki:<b>https://bayi.newglobalinsaat.com/</b><br/>Kullanıcı Ad:<b>" + kullaniciAdi + "</b><br/>Şifre:<b>" + sayi + "</b><br/>Bilgileri İle Sisteme Giriş Yapabilirsiniz.");
            }
            else
            {
                result.IsSuccessful = false;
                result.Content = "Bu Kullanıcı Adı Sisteme Zaten Kayıtlı.";

            }
            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string KullaniciSil(string LOGICALREF)
        {
            var result = new RestSharp.RestResponse();

            try
            {
                var db = new Models.NewGlobalDBEntities();
                db.Database.ExecuteSqlCommand("delete from Kullanicilar where LOGICALREF=" + LOGICALREF);
                result.IsSuccessful = true;
                result.Content = "Kullanıcı Başarıyla Silindi.";
            }
            catch (Exception hata)
            {
                result.IsSuccessful = false;
                result.Content = "Kullanıcı Silinemedi.Hata="+hata.Message;
            }
            return JsonConvert.SerializeObject(result);
        }
    }
}