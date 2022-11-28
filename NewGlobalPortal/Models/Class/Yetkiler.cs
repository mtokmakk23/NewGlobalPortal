using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGlobalPortal.Models.Class
{
    public class Yetkiler
    {
        public KullaniciYetkileri yetki = new KullaniciYetkileri();
        public Kullanicilar kullanici = new Kullanicilar();
        public Parametreler parametre = new Parametreler();

        public Yetkiler()
        {
            try
            {
                kullanici = JsonConvert.DeserializeObject<Kullanicilar>(HttpContext.Current.Session["kullanici"].ToString());
              
            }
            catch (Exception)
            {
                
            }
           try
            {
                yetki = JsonConvert.DeserializeObject<KullaniciYetkileri>(HttpContext.Current.Session["yetki"].ToString());

            }
            catch (Exception)
            {
                
            }
           try
            {
               parametre = JsonConvert.DeserializeObject<Parametreler>(HttpContext.Current.Session["parametre"].ToString());

            }
            catch (Exception)
            {
                
            }
           
        }

    }
}