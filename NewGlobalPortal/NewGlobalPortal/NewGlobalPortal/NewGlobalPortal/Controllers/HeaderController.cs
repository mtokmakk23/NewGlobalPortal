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
            if (Yetkiler.kullanici.LOGICALREF == 0)
            {
                SessionsInfo oturum = new SessionsInfo();
                oturum.oturumTanimla();
            }
            ViewBag.HesapEkstresiniGorebilirMi = Yetkiler.yetki.HesapEkstresiniGorebilirMi;
            ViewBag.IrsaliyeleriGorebilirMi = Yetkiler.yetki.IrsaliyeleriGorebilirMi;
            ViewBag.SiparisleriGorebilirMi = Yetkiler.yetki.SiparisleriGorebilirMi;
            ViewBag.SiparisOluturabilirMi = Yetkiler.yetki.SiparisOluturabilirMi;
            ViewBag.AdminMi = Yetkiler.kullanici.AdminMi;
            ViewBag.KullaniciAdi = Yetkiler.kullanici.KullaniciAdi;
            if (Yetkiler.kullanici.PortalAdmini==true)
            {
                ViewBag.BayiAdi = "";
            }
            else
            {
                ViewBag.BayiAdi = (Yetkiler.kullanici.YetkiliOlduguCariAdi.Length > 20) ? Yetkiler.kullanici.YetkiliOlduguCariAdi.Substring(0, 20) + ".." : Yetkiler.kullanici.YetkiliOlduguCariAdi;

            }
            return PartialView();


        }

      

       
    }
}