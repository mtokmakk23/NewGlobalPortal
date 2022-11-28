using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGlobalPortal.Models.Class
{
    public class SessionsInfo
    {
        UyumsoftApi api = new UyumsoftApi();
        
        public void oturumTanimla()
        {
            Yetkiler yetki = new Yetkiler();
            var db = new Models.NewGlobalDBEntities();
            var query = from a in db.Kullanicilars
                        join x in db.KullaniciYetkileris on a.LOGICALREF equals x.KullaniciId
                        where a.LOGICALREF.ToString() == HttpContext.Current.User.Identity.Name
                        select new { a, x };
            yetki.parametre = db.Parametrelers.Take(1).FirstOrDefault();
            HttpContext.Current.Session["parametre"] = JsonConvert.SerializeObject(yetki.parametre);
            foreach (var item in query)
            {
                item.a.CariGrupKodu = api.CariGrupKodunuDonder(item.a.YetkiliOlduguCariIdleri);
                HttpContext.Current.Session["kullanici"] = JsonConvert.SerializeObject(item.a);
                HttpContext.Current.Session["yetki"] = JsonConvert.SerializeObject(item.x);
                yetki.kullanici = item.a;
                yetki.yetki = item.x;
                break;
            }
        }
    }
}