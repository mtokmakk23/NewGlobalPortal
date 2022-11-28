using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGlobalPortal.Models.Class
{
    public class TumUrunler
    {
        public string TumUrunlerStr { set; get; }

        public TumUrunler()
        {
            try
            {
                TumUrunlerStr = HttpContext.Current.Session["tumUrunler"].ToString();

            }
            catch (Exception)
            {

            }
        }
    }
}