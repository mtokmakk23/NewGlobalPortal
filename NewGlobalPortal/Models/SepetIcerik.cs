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
    
    public partial class SepetIcerik
    {
        public long LOGICALREF { get; set; }
        public Nullable<long> BaslikRef { get; set; }
        public Nullable<int> UrunId { get; set; }
        public string UrunAdi { get; set; }
        public Nullable<double> IndirimliFiyat { get; set; }
        public Nullable<double> IndirimsizFiyat { get; set; }
        public Nullable<double> IndirimOrani { get; set; }
        public Nullable<int> IndirimOraniID { get; set; }
        public string IndirimOraniKodu { get; set; }
        public Nullable<int> FiyatListesiId { get; set; }
        public string FiyatListesiAdi { get; set; }
        public Nullable<System.DateTime> EklenmeTarihi { get; set; }
        public Nullable<System.DateTime> GuncellemeTarihi { get; set; }
        public string Ekleyen { get; set; }
        public Nullable<double> Miktar { get; set; }
        public string Url { get; set; }
        public string KdvKodu { get; set; }
        public Nullable<double> KdvOrani { get; set; }
        public Nullable<double> KdvTutari { get; set; }
        public string KdvDurumu { get; set; }
        public string KurKodu { get; set; }
        public Nullable<double> KurDegeri { get; set; }
        public string BirimKodu { get; set; }
        public string TevkifatKodu { get; set; }
        public Nullable<double> TevkifatOrani { get; set; }
        public string UrunKodu { get; set; }
        public string Marka { get; set; }
        public string Kategori { get; set; }
        public string LineType { get; set; }
    }
}
