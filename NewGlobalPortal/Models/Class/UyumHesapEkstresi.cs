using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGlobalPortal.Models.Class
{



    

    public class UyumHesapEkstresi
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public UyumHesapEkstresiResult[] result { get; set; }
    }

    public class UyumHesapEkstresiResult
    {
        public int fiN_M_ID { get; set; }
        public int fiN_D_ID { get; set; }
        public string firmA_KOD { get; set; }
        public string firmA_AD { get; set; }
        public string isyerI_KOD { get; set; }
        public string isyerI_AD { get; set; }
        public string carI_KOD { get; set; }
        public string carI_AD { get; set; }
        public string vergI_NO { get; set; }
        public string vergI_DAIRESI { get; set; }
        public string teL1 { get; set; }
        public string teL2 { get; set; }
        public string faks { get; set; }
        public object adres { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public DateTime belgE_TARIH { get; set; }
        public string belgE_NO { get; set; }
        public string fiS_NO { get; set; }
        public string kaynaK_PROGRAM { get; set; }
        public string fiS_TIPI { get; set; }
        public string isleM_TIPI { get; set; }
        public string aciklamA1 { get; set; }
        public object aciklamA2 { get; set; }
        public float borC_TUTAR { get; set; }
        public float alacaK_TUTAR { get; set; }
        public float doviZ_BORC_TUTAR { get; set; }
        public float doviZ_ALACAK_TUTAR { get; set; }
        public string parA_BIRIMI { get; set; }
        public float kur { get; set; }
        public DateTime vadE_TARIHI { get; set; }
        public object ozeL_KOD1 { get; set; }
        public object ozeL_KOD2 { get; set; }
    }

}