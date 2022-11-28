using NewGlobalPortal.Models;
using NewGlobalPortal.Models.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NewGlobalPortal.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        UyumsoftApi api = new UyumsoftApi();

        // GET: Login
        public ActionResult Index()
        {



            //Response.Cookies.Remove(".ASPXAUTH");

            return View();
        }



        [HttpPost]
        public ActionResult Index(Kullanicilar User)
        {
            Yetkiler yetki = new Yetkiler();
            string md5Sifre = MD5Hashh.MD5Sifrele(User.Sifre);
            var db = new Models.NewGlobalDBEntities();
            var userInDb = db.Kullanicilars.Where(x => x.KullaniciAdi == (User.KullaniciAdi) && (x.Sifre == (md5Sifre) || (x.AktivasyonSifresi == User.Sifre)) && x.Statu == (true)).FirstOrDefault();
            if (userInDb != null)
            {
                if (Convert.ToDateTime(userInDb.EnSonSifreDegistirmeTarihi).AddDays(90) < DateTime.Now || userInDb.AktivasyonSifresi == User.Sifre)
                {
                    var activation = new ActivationInfo();
                    activation.AdiSoyadi = userInDb.AdiSoyadi;
                    activation.KullaniciAdi = userInDb.KullaniciAdi;
                    activation.kullaniciID = userInDb.LOGICALREF.ToString();
                    activation.SonGecerlilikTarihi = DateTime.Now.AddHours(2).ToString();
                    var temp = Aes256CbcEncrypter.Encrypt(JsonConvert.SerializeObject(activation));
                    return Redirect("/Activation/Index?value=" + temp);
                }
                FormsAuthentication.SetAuthCookie(userInDb.LOGICALREF.ToString(), false);


                if (userInDb.PortalAdmini == true)
                {
                    var kyetki = db.KullaniciYetkileris.Where(x => x.KullaniciId == userInDb.LOGICALREF).FirstOrDefault();
                    if (kyetki == null)
                    {
                        kyetki = new KullaniciYetkileri();
                        kyetki.HesapEkstresiniGorebilirMi = true;
                        kyetki.IrsaliyeleriGorebilirMi = true;
                        kyetki.KullaniciId = userInDb.LOGICALREF;
                        kyetki.SiparisleriGorebilirMi = true;
                        kyetki.SiparisOluturabilirMi = true;
                        db.KullaniciYetkileris.Add(kyetki);
                        db.SaveChanges();
                    }



                }

                yetki.parametre = db.Parametrelers.Take(1).FirstOrDefault();
                var query = from a in db.Kullanicilars
                            join x in db.KullaniciYetkileris on a.LOGICALREF equals x.KullaniciId
                            where a.LOGICALREF == userInDb.LOGICALREF
                            select new { a, x };
                Session["parametre"] = JsonConvert.SerializeObject(yetki.parametre);
                var GrupKodu = api.CariGrupKodunuDonder(userInDb.YetkiliOlduguCariIdleri);
                foreach (var item in query)
                {
                    item.a.CariGrupKodu = GrupKodu;
                    yetki.kullanici = item.a;
                    yetki.yetki = item.x;
                    break;
                }

                Session["kullanici"] = JsonConvert.SerializeObject(yetki.kullanici);
                Session["yetki"] = JsonConvert.SerializeObject(yetki.yetki);
                Session["tumUrunler"] = api.Urunler();
                userInDb.AktivasyonSifresi = "";
                userInDb.CariGrupKodu = GrupKodu;
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı!";
                return View();
            }

        }


        [HttpPost]
        public string aktivasyonSifresiGonder(string kullaniciAdi)
        {
            var result = new RestSharp.RestResponse();
            int sayi = 0;
            Random rastgele = new Random();
            var db = new Models.NewGlobalDBEntities();
            try
            {
                var kullanicilar = db.Kullanicilars.Where(x => x.KullaniciAdi == kullaniciAdi).FirstOrDefault();
                if (kullanicilar != null)
                {

                    sayi = rastgele.Next(100000, 999999);
                    kullanicilar.AktivasyonSifresi = sayi.ToString();
                    db.SaveChanges();
                    MailIslemleri mail = new MailIslemleri();

                    if (mail.EksizMailGonderme("", kullanicilar.MailAdresi, "Yeni Şifre Talebi", "Değerli Üyemiz Yenileme Şifreniz Aşağıda Verilmiştir. <br/><br/>" +
                        "Kullanıcı Ad:<b>" + kullaniciAdi + "</b><br/>Şifre:<b>" + sayi + "</b><br/><br/>Bilgileri İle Sisteme Giriş Yapabilirsiniz."))
                    {
                        result.IsSuccessful = true;
                        result.Content = "Yenileme Şifresi Mail Adresinize Gönderilmiştir";
                    }
                    else
                    {
                        result.IsSuccessful = false;
                        result.Content = "Yenileme Şifresi Gönderilirken Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz.";
                    }

                }
                else
                {
                    result.IsSuccessful = false;
                    result.Content = "Kullanıcı Bulunamadı.";
                }
            }
            catch (Exception hata)
            {
                result.IsSuccessful = false;
                result.Content = hata.Message;
            }
            return JsonConvert.SerializeObject(result);
        }

    }
}