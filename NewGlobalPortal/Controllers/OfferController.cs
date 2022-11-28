using NewGlobalPortal.Models;
using NewGlobalPortal.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGlobalPortal.Controllers
{
    public class OfferController : Controller
    {
        
        UyumsoftApi api = new UyumsoftApi();

        // GET: Offer
        public ActionResult Index()
        {
            Yetkiler yetki = new Yetkiler();
            if (Convert.ToBoolean(yetki.yetki.SiparisleriGorebilirMi))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public string TeklifleriGetir()
        {
            Yetkiler yetki = new Yetkiler();
            return api.TeklifleriGetir(yetki.kullanici.YetkiliOlduguCariIdleri);
        }
    }
}