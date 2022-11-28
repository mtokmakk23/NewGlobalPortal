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
 
    public class OrdersController : Controller
    {
        
        UyumsoftApi api = new UyumsoftApi();
        // GET: Orders
        public ActionResult Index()
        {
            Yetkiler yetki = new Yetkiler();
            if (Convert.ToBoolean(yetki.yetki.SiparisleriGorebilirMi))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
           
        }

        [HttpPost]
        public string SiparisleriGetir()
        {
            return api.Siparisler();
        }
    }
}