using NewGlobalPortal.Models;
using NewGlobalPortal.Models.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace NewGlobalPortal.Controllers
{
    public class BankStatementController : Controller
    {
        UyumsoftApi api = new UyumsoftApi();
        
        // GET: BankStatement
        public ActionResult Index()
        {
            Yetkiler yetki = new Yetkiler();
            if (Convert.ToBoolean(yetki.yetki.HesapEkstresiniGorebilirMi))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public string HesapEkstresiniGetir()
        {
            Yetkiler yetki = new Yetkiler();
            return api.HesapEkstresi(yetki.kullanici.YetkiliOlduguCariIdleri);


        }
        [HttpPost]
        public string FaturaIndir(string BelgeNo)
        {

            return api.FaturalarBelgesiOlustur(BelgeNo);



        }

    }
}