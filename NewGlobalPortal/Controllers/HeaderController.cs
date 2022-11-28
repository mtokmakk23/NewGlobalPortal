using NewGlobalPortal.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NewGlobalPortal.Controllers
{
    public class HeaderController : Controller
    {

        // GET: Header
        public ActionResult Index()
        {
            try
            {
                Yetkiler yetki = new Yetkiler();
                if (yetki.kullanici.LOGICALREF == 0)
                {
                    SessionsInfo oturum = new SessionsInfo();
                    oturum.oturumTanimla();
                }
                ViewBag.HesapEkstresiniGorebilirMi = yetki.yetki.HesapEkstresiniGorebilirMi;
                ViewBag.IrsaliyeleriGorebilirMi = yetki.yetki.IrsaliyeleriGorebilirMi;
                ViewBag.SiparisleriGorebilirMi = yetki.yetki.SiparisleriGorebilirMi;
                ViewBag.SiparisOluturabilirMi = yetki.yetki.SiparisOluturabilirMi;
                ViewBag.AdminMi = yetki.kullanici.AdminMi;
                ViewBag.KullaniciAdi = yetki.kullanici.KullaniciAdi;
                if (yetki.kullanici.PortalAdmini == true)
                {
                    ViewBag.BayiAdi = "";
                }
                else
                {
                    ViewBag.BayiAdi = (yetki.kullanici.YetkiliOlduguCariAdi.Length > 20) ? yetki.kullanici.YetkiliOlduguCariAdi.Substring(0, 20) + ".." : yetki.kullanici.YetkiliOlduguCariAdi;

                }
            }
            catch (Exception)
            {
                ViewBag.HesapEkstresiniGorebilirMi = false;
                ViewBag.IrsaliyeleriGorebilirMi = false;
                ViewBag.SiparisleriGorebilirMi = false;
                ViewBag.SiparisOluturabilirMi = false;
                ViewBag.AdminMi = false;
                ViewBag.KullaniciAdi = false;

                ViewBag.BayiAdi = "";
            }

            return PartialView();


        }




    }
}