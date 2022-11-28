using NewGlobalPortal.Models;
using NewGlobalPortal.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGlobalPortal.Controllers
{
    public class DispatchController : Controller
    {
        UyumsoftApi api = new UyumsoftApi();
        
        // GET: Dispatch
        public ActionResult Index()
        {
            Yetkiler yetki = new Yetkiler();
            if (Convert.ToBoolean(yetki.yetki.IrsaliyeleriGorebilirMi))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public string IrsaliyeleriGetir()
        {
            return api.Irsaliyeler();
        }
    }
}