//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewGlobalPortal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kullanicilar
    {
        public long LOGICALREF { get; set; }
        public string MailAdresi { get; set; }
        public string Sifre { get; set; }
        public Nullable<bool> Statu { get; set; }
        public string AdiSoyadi { get; set; }
        public string Gsm { get; set; }
        public string YetkiliOlduguCariIdleri { get; set; }
        public Nullable<bool> AdminMi { get; set; }
        public Nullable<System.DateTime> EnSonSifreDegistirmeTarihi { get; set; }
        public string KullaniciAdi { get; set; }
        public Nullable<bool> PortalAdmini { get; set; }
        public string AktivasyonSifresi { get; set; }
        public string YetkiliOlduguCariAdi { get; set; }
        public string CariGrupKodu { get; set; }
    }
}
