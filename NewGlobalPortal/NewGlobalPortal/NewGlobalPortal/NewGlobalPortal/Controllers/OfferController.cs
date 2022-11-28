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
            if (Convert.ToBoolean(Yetkiler.yetki.SiparisleriGorebilirMi))
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
            return api.TeklifleriGetir(Yetkiler.kullanici.YetkiliOlduguCariIdleri);
        }
    }
}