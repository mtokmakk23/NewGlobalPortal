﻿using NewGlobalPortal.Models;
using NewGlobalPortal.Models.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGlobalPortal.Controllers
{
    public class ProductsController : Controller
    {
        UyumsoftApi api = new UyumsoftApi();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string UrunleriGetir()
        {
          
            var urunFiyati = JsonConvert.DeserializeObject<List<UyumUrunlerResult>>(api.Urunler());
           
            foreach (var item in urunFiyati)
            {
                item.itemPriceList = item.itemPriceList.Where(x => x.priceListCode.Contains("#NK")).ToArray();
               
              
            }
           
            return JsonConvert.SerializeObject(urunFiyati);
        }
      

        [HttpPost]
        public string SepeteEkle(string itemCode, string miktar)
        {
            var result = new RestSharp.RestResponse();
            try
            {
                var urun = JsonConvert.DeserializeObject<List<UyumUrunlerResult>>(api.FiltreliUrunGetir(itemCode));

                if (urun.Count() == 0)
                {
                    result.IsSuccessful = false;
                    result.Content = "Ürün Bulunamadı";
                }
                else
                {
                    var donusum = api.BirimDonusumu(urun[0].id.ToString(),Convert.ToDouble(miktar.Replace(",", ".")), urun[0].itemCode.ToString(), urun[0].itemName.ToString());
                    if (donusum!="OK")
                    {
                        result.IsSuccessful = false;
                        result.Content = donusum;
                    }
                    else
                    {
                        var cariBilgileri = api.FiltreliCariGetir(Yetkiler.kullanici.YetkiliOlduguCariIdleri);
                        var db = new Models.NewGlobalDBEntities();

                        var sepetBasligi = db.SepetBasligis.Where(x => x.Ekleyen.Equals(Yetkiler.kullanici.KullaniciAdi)).FirstOrDefault();
                        if (sepetBasligi == null)
                        {
                            sepetBasligi = new SepetBasligi();
                            sepetBasligi.IsYeriKodu = Yetkiler.parametre.IsYeriKodu;
                            sepetBasligi.Tarih = DateTime.Now;
                            sepetBasligi.HareketKodu = Yetkiler.parametre.HareketKodu;
                            sepetBasligi.ParaBirimi = "TRY";
                            sepetBasligi.CariKodu = cariBilgileri.result.entitY_M[0].entityCode;
                            sepetBasligi.CariAdi = cariBilgileri.result.entitY_M[0].entityName;
                            sepetBasligi.KurSecenegi = "Sevk_Tarihindeki_Kur";
                            sepetBasligi.Ekleyen = Yetkiler.kullanici.KullaniciAdi;
                            sepetBasligi.EklenmeTarihi = DateTime.Now;
                            sepetBasligi.OdemePlani = "";
                            sepetBasligi.OdemeSekli = "";
                            sepetBasligi.OdemeSekli = "";
                            sepetBasligi.SevkIli = "";
                            sepetBasligi.SevkIlce = "";
                            sepetBasligi.SevkAdresi = "";
                            db.SepetBasligis.Add(sepetBasligi);
                            db.SaveChanges();
                        }
                        var id = urun[0].id.ToString();
                        var vturun = db.SepetIceriks.Where(x => x.UrunId.ToString().Equals(id) && x.BaslikRef.ToString().Equals(sepetBasligi.LOGICALREF.ToString())).FirstOrDefault();
                        float fiyat = 0;

                        if (vturun == null)
                        {
                            vturun = new SepetIcerik();


                            vturun.BaslikRef = sepetBasligi.LOGICALREF;
                            vturun.EklenmeTarihi = DateTime.Now;
                            vturun.Ekleyen = Yetkiler.kullanici.KullaniciAdi;
                            vturun.Url = "";
                            foreach (var item in urun)
                            {

                                foreach (var item2 in item.itemPriceList)
                                {
                                    if (item2.priceListCode.Contains("#NK"))
                                    {
                                        if (item2.sonFiyat == 0)
                                        {
                                        }
                                        else
                                        {
                                            fiyat = item2.sonFiyat;
                                            vturun.IndirimliFiyat = item2.sonFiyat;
                                            vturun.IndirimsizFiyat = item2.unitPriceTra;
                                            vturun.IndirimOrani = item2.disc1Rate;
                                            vturun.IndirimOraniKodu = item2.discCode1;
                                            vturun.FiyatListesiAdi = item2.priceListCode;
                                            vturun.FiyatListesiId = item2.priceListId;

                                            break;
                                        }

                                    }
                                }
                                vturun.TevkifatKodu = item.categories17Code;
                                vturun.KdvKodu = item.defaultTaxCode;
                                vturun.KdvOrani = Convert.ToDouble(item.defaultTaxRate.Replace(",", "."));
                                vturun.KdvTutari = Convert.ToDouble(item.defaultTaxRate.Replace(",", ".")) / 100;
                                vturun.BirimKodu = item.unitId.ToString();
                                vturun.KdvDurumu = Yetkiler.parametre.SatisSiparisiKdvDurumu;
                                vturun.KurDegeri = 1;
                                vturun.KurKodu = "TRY";
                                vturun.UrunId = Convert.ToInt32(item.id);
                                vturun.UrunAdi = item.itemName;
                                vturun.UrunKodu = item.itemCode;
                                vturun.Kategori = item.categories2Code;
                                vturun.Marka = item.categories8Code;


                                foreach (var item2 in item.itemImageList)
                                {
                                    vturun.Url = item2.ToString();
                                    break;

                                }
                            }

                            vturun.GuncellemeTarihi = DateTime.Now;
                            try
                            {
                                vturun.Miktar = Convert.ToDouble(miktar);
                            }
                            catch (Exception)
                            {

                                vturun.Miktar = 1;
                            }

                            db.SepetIceriks.Add(vturun);

                        }
                        else
                        {
                            foreach (var item in urun)
                            {

                                foreach (var item2 in item.itemPriceList)
                                {
                                    if (item2.priceListCode.Contains("#NK"))
                                    {
                                        if (item2.sonFiyat == 0)
                                        {

                                        }
                                        else
                                        {
                                            fiyat = item2.sonFiyat;
                                            vturun.IndirimliFiyat = item2.sonFiyat;
                                            vturun.IndirimsizFiyat = item2.unitPriceTra;
                                            vturun.IndirimOrani = item2.disc1Rate;
                                            vturun.IndirimOraniKodu = item2.discCode1;
                                            vturun.FiyatListesiAdi = item2.priceListCode;
                                            vturun.FiyatListesiId = item2.priceListId;

                                            break;
                                        }
                                    }
                                }
                                vturun.KdvKodu = item.defaultTaxCode;
                                vturun.KdvOrani = Convert.ToDouble(item.defaultTaxRate.Replace(",", "."));
                                vturun.KdvTutari = Convert.ToDouble(item.defaultTaxRate.Replace(",", ".")) / 100;
                                vturun.BirimKodu = item.unitId.ToString();
                                vturun.KdvDurumu = Yetkiler.parametre.SatisSiparisiKdvDurumu;
                                vturun.KurDegeri = 1;
                                vturun.KurKodu = "TRY";
                                try
                                {
                                    vturun.Miktar = vturun.Miktar + Convert.ToDouble(miktar);
                                }
                                catch (Exception)
                                {

                                    vturun.Miktar = vturun.Miktar + 1;
                                }

                            }

                            vturun.GuncellemeTarihi = DateTime.Now;

                        }
                        if (fiyat == 0)
                        {
                            result.IsSuccessful = false;
                            result.Content = "Fiyatı Olmayan Sepete Ürün Eklenemez.";
                            MailIslemleri mail = new MailIslemleri();
                            mail.EksizMailGonderme("", "info@newglobalinsaat.com", "Fiyatı Olmayan Ürün", vturun.UrunAdi);

                        }
                        else
                        {
                            db.SaveChanges();
                            

                            result.IsSuccessful = true;
                            result.Content = "Ürün Sepete Eklendi";
                        }
                    }


                  

                }
            }
            catch (Exception hata)
            {
                result.IsSuccessful = false;
                result.Content = "Ürün Sepete Eklenemedi. Hata Mesajı:" + hata.Message;
            }

            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string SepetCek()
        {
            try
            {
                var db = new Models.NewGlobalDBEntities();
                var vturun = db.SepetIceriks.Where(x => x.Ekleyen.Equals(Yetkiler.kullanici.KullaniciAdi)).ToList();
                foreach (var item in vturun)
                {
                    if (item.GuncellemeTarihi < Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy 00:00")))
                    {
                        var urunFiyati = JsonConvert.DeserializeObject<List<UyumUrunlerResult>>(api.FiltreliUrunGetir(item.UrunKodu.ToString()));
                        var sepetUrun = db.SepetIceriks.Where(x => x.LOGICALREF.Equals(item.LOGICALREF)).FirstOrDefault();
                        sepetUrun.IndirimliFiyat = 0;
                        sepetUrun.FiyatListesiAdi = "";
                        foreach (var item2 in urunFiyati)
                        {
                            foreach (var item3 in item2.itemPriceList)
                            {
                                if (item3.priceListCode.Contains("#NK"))
                                {
                                    sepetUrun.IndirimliFiyat = item3.sonFiyat;
                                    sepetUrun.IndirimsizFiyat = item3.unitPriceTra;
                                    sepetUrun.IndirimOrani = item3.disc1Rate;
                                    sepetUrun.IndirimOraniKodu = item3.discCode1;
                                    sepetUrun.FiyatListesiAdi = item3.priceListCode;
                                    sepetUrun.FiyatListesiId = item3.priceListId;

                                    sepetUrun.GuncellemeTarihi = DateTime.Now;
                                    db.SaveChanges();
                                    break;
                                }
                            }

                        }

                    }
                }
                return JsonConvert.SerializeObject(vturun);
            }
            catch (Exception hata)
            {
                return hata.Message;
            }
            

        }


        [HttpPost]
        public string SepetMiktarlariniGuncelle(string LOGICALREF, string Miktar)
        {
            var result = new RestSharp.RestResponse();

            try
            {
                var db = new Models.NewGlobalDBEntities();
                var sepetIcerik = db.SepetIceriks.Where(x => x.LOGICALREF.ToString().Equals(LOGICALREF)).FirstOrDefault();
                sepetIcerik.Miktar = Convert.ToDouble(Miktar);
                db.SaveChanges();
                result.IsSuccessful = true;
                result.Content = "Ürün Güncellendi.";
            }
            catch (Exception hata)
            {
                result.IsSuccessful = false;
                result.Content = "Ürün Miktarı Güncellenirken Hata Oluştu. Hata:" + hata.Message;

            }

            return JsonConvert.SerializeObject(result);

        }
        [HttpPost]
        public string SepettenSil(string LOGICALREF)
        {
            var result = new RestSharp.RestResponse();

            try
            {
                var db = new Models.NewGlobalDBEntities();
                db.Database.ExecuteSqlCommand("delete from SepetIcerik where LOGICALREF=" + LOGICALREF);
                result.IsSuccessful = true;
                result.Content = "Ürün Silindi.";
            }
            catch (Exception hata)
            {
                result.IsSuccessful = false;
                result.Content = "Ürün Sepetten Silinirken Hata Oluştu. Hata:" + hata.Message;

            }

            return JsonConvert.SerializeObject(result);
        }

        public ActionResult CompleteOrder()
        {

            if (Convert.ToBoolean(Yetkiler.yetki.SiparisOluturabilirMi))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public string odemeTipineGoreFiyatlariGuncelle(string OdemeTipi)
        {
            var result = new RestSharp.RestResponse();
            var db = new Models.NewGlobalDBEntities();

            var transaction = db.Database.BeginTransaction();
            try
            {
                var vturun = db.SepetIceriks.Where(x => x.Ekleyen.Equals(Yetkiler.kullanici.KullaniciAdi)).ToList();
                foreach (var item in vturun)
                {

                    var urunFiyati = JsonConvert.DeserializeObject<List<UyumUrunlerResult>>(api.FiltreliUrunGetir(item.UrunKodu.ToString()));
                    var sepetUrun = db.SepetIceriks.Where(x => x.LOGICALREF.Equals(item.LOGICALREF)).FirstOrDefault();
                    sepetUrun.IndirimliFiyat = 0;
                    sepetUrun.FiyatListesiAdi = "";
                    foreach (var item2 in urunFiyati)
                    {
                        foreach (var item3 in item2.itemPriceList)
                        {
                            if (item3.priceListCode.Contains(OdemeTipi))
                            {

                                sepetUrun.IndirimliFiyat = item3.sonFiyat;
                                sepetUrun.IndirimsizFiyat = item3.unitPriceTra;
                                sepetUrun.IndirimOrani = item3.disc1Rate;
                                sepetUrun.IndirimOraniKodu = item3.discCode1;
                                sepetUrun.FiyatListesiAdi = item3.priceListCode;
                                sepetUrun.FiyatListesiId = item3.priceListId;
                                sepetUrun.GuncellemeTarihi = DateTime.Now;
                                db.SaveChanges();
                                break;
                            }
                        }

                    }
                    db.SaveChanges();

                }
                transaction.Commit();
                result.IsSuccessful = true;
                result.Content = "Fiyatlar Güncellendi.";
            }
            catch (Exception hata)
            {
                transaction.Rollback();
                result.IsSuccessful = false;
                result.Content = "Fiyatlar Değişirken Hata Oluştu. Hata:" + hata.Message;

            }

            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string sehirleriGetir()
        {
            return api.Sehirler();
        }

        [HttpPost]
        public string ilceleriGetir(string citY_ID)
        {
            return api.Iceler(citY_ID);
        }


        [HttpPost]
        public string siparisiTamamla(string BaslikLogicalref,string OdemeTipi,string ilgiliKisi,string tel,string detayliAdres,string city,string towN,string siparisAciklamasi)
        {
            return api.TeklifOlustur(BaslikLogicalref, OdemeTipi, ilgiliKisi, tel, detayliAdres, city, towN, siparisAciklamasi);
        }
    }
}