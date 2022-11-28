using NewGlobalPortal.Models.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGlobalPortal.Controllers
{
    [AllowAnonymous]
    public class ActivationController : Controller
    {
        // GET: Activation
        public ActionResult Index(string value)
        {
            if (value==null)
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                try
                {
                    var sonuc = Aes256CbcEncrypter.Decrypt(value);
                    var info = JsonConvert.DeserializeObject<ActivationInfo>(sonuc);
                    if (Convert.ToDateTime(info.SonGecerlilikTarihi)>DateTime.Now)
                    {
                        ViewBag.KullaniciAdi = info.KullaniciAdi;
                        ViewBag.AdiSoyadi = info.AdiSoyadi;
                        ViewBag.kullaniciID = info.kullaniciID;
                        ViewBag.value = value;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index", "Login");
                    }
                   
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Login");
                }
              
              
            }
         
        }

        [HttpPost]
        public string NewPassword(string kullaniciID, string adiSoyadi, string kullaniciAdi, string yeniSifre, string yeniSifreTekrar)
        {
            var result = new RestSharp.RestResponse();
            try
            {
              
                var db = new Models.NewGlobalDBEntities();
                var kullanici = db.Kullanicilars.Where(x => x.KullaniciAdi == kullaniciAdi && x.LOGICALREF.ToString()== kullaniciID).FirstOrDefault();
                if (kullanici!=null)
                {
                    if (sifreUygunMu(yeniSifre,yeniSifreTekrar)=="OK")
                    {
                        kullanici.Sifre = MD5Hashh.MD5Sifrele(yeniSifre);
                        kullanici.EnSonSifreDegistirmeTarihi = DateTime.Now;
                        db.SaveChanges();
                        result.IsSuccessful = true;
                        result.Content = "Şifre Değiştirildi Giriş Yapabilirsiniz.";
                    }
                    else
                    {
                        result.IsSuccessful = false;
                        result.Content = sifreUygunMu(yeniSifre, yeniSifreTekrar);

                    }

                }
                else
                {
                    result.IsSuccessful = false;
                    result.Content = "Kullanıcı Bulunamadı";
                }
            }
            catch (Exception hata)
            {
                result.IsSuccessful = false;
                result.Content = hata.Message;
              
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


    }
}