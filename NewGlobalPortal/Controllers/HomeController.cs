using NewGlobalPortal.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NewGlobalPortal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //try
            //{
               
            //    Response.Headers.Add("set-cookie", ".ASPXAUTH=" + Request.Cookies[".ASPXAUTH"].Value + "; path=/; SameSite=None;secure");
            //}
            //catch (Exception hata)
            //{
            //    ViewBag.Hata = hata.Message;
            //}
            //try
            //{
            //    Response.Headers.Add("set-cookie", "ASP.NET_SessionId=" + Request.Cookies["ASP.NET_SessionId"].Value + "; path=/; SameSite=None;secure");
            //}
            //catch (Exception)
            //{
            //}


            return View();
        }

        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            HttpContext.Request.Cookies.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}