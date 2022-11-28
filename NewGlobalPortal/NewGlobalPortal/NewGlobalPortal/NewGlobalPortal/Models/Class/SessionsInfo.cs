using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGlobalPortal.Models.Class
{
    public class SessionsInfo
    {
        public void oturumTanimla()
        {

            var db = new Models.NewGlobalDBEntities();
            var query = from a in db.Kullanicilars
                        join x in db.KullaniciYetkileris on a.LOGICALREF equals x.KullaniciId
                        where a.LOGICALREF.ToString() == HttpContext.Current.User.Identity.Name
                        select new { a, x };
            foreach (var item in query)
            {
                Yetkiler.kullanici = item.a;
                Yetkiler.yetki = item.x;
                break;
            }
        }
    }
}