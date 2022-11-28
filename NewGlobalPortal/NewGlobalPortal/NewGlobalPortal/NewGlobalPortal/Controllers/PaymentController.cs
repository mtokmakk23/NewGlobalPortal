using NewGlobalPortal.Models;
using NewGlobalPortal.Models.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGlobalPortal.Controllers
{
    public class PaymentController : Controller
    {
        SanalPosService.AuthenticationInfo aut = new SanalPosService.AuthenticationInfo();
        private class SiparisDetaylari
        {
            public string BaslikLogicalref { set; get; }
            public string OdemeTipi { set; get; }
            public string ilgiliKisi { set; get; }
            public string tel { set; get; }
            public string detayliAdres { set; get; }
            public string city { set; get; }
            public string towN { set; get; }
            public string siparisAciklamasi { set; get; }
            public double tutar { set; get; }
        }
        public PaymentController()
        {
            aut.UserName = "newglobalyapimuhasebe@gmail.com";
          //  aut.Password = "NewGlobal123?";//demo
            aut.Password = "12345CeŞA";//canlı
        }

   
        [HttpPost]
        public ActionResult PaymentResult(string resultUrl)
        {
            try
            {
                ViewBag.Sonuc = "<table class='table table-striped table-sm'>";
                MailIslemleri mail = new MailIslemleri();


                var sonuc = Request.Form["TransactionStatusId"];
                var sonuc2 = Request.Form["OrderReference"];
                var sonuc3 = Request.Form["BankMessage"];
                var sonuc4 = Request.Form["PaymentGuid"];
                if (sonuc4 != null)
                {
                  
                       var result = OdemeKontrol(sonuc4);
                    if (result.TransactionStatusId == 1)
                    {
                        ViewBag.Sonuc +=
                              "<tr><td>Durumu:</td><td class='text-success'><i class='fa-solid fa-check-double'></i>Kredi Kartı Ödemesi Başarılı</td></tr>" +
                              "<tr><td>Referans Kodu:</td><td>" + result.ReferenceCode + "</td></tr>";

                        mail.EksizMailGonderme("", "satis@newglobalinsaat.com,info@newglobalinsaat.com,yonetim@newglobalinsaat.com","Kredi Kartı Ödemesi", 
                             "<table><tr><td>Durumu:</td><td class='text-success'><i class='fa-solid fa-check-double'></i>Kredi Kartı Ödemesi Başarılı</td></tr>" +
                              "<tr><td>Referans Kodu:</td><td>" + result.ReferenceCode + "</td></tr><tr><td>Cari Adı:</td><td>" + Yetkiler.kullanici.YetkiliOlduguCariAdi + "</td></tr></table>");
                       var siparisDetaylari = JsonConvert.DeserializeObject<SiparisDetaylari>(Aes256CbcEncrypter.Decrypt(resultUrl));
                        UyumsoftApi sipComplate = new UyumsoftApi();
                        if (Yetkiler.kullanici.YetkiliOlduguCariIdleri!="" && Yetkiler.kullanici.YetkiliOlduguCariIdleri!=null)
                        {
                            var virmanCevabi = sipComplate.VirmanOlustur(Math.Round(siparisDetaylari.tutar, 2), result.ReferenceCode);
                            if (virmanCevabi.IsSuccessful)
                            {
                                var aaa = JsonConvert.DeserializeObject<UyumVirmanOnaySonucu>(virmanCevabi.Content);
                                if (aaa.statusCode == 200)
                                {
                                    ViewBag.Sonuc += "<tr><td>Durumu:</td><td class='text-success'><i class='fa-solid fa-check-double'></i>Finans Kaydı Oluşturuldu</td></tr>" +
                              "<tr><td>Sonuc:</td><td>" + aaa.message + "</td></tr>" +
                              "<tr><td>Dikkat:</td><td><small>Her Kredi Kartı Çekiminden Sonra Hesap Hareketleri Kısmından İşlemi Kontrol Ediniz.</small></td></tr>";
                                }
                                else
                                {
                                    mail.EksizMailGonderme("mehmettokmak184@gmail.com", "satis@newglobalinsaat.com,info@newglobalinsaat.com,yonetim@newglobalinsaat.com", "Virman Oluşturma Hatası",
                                        "<b>Yapılan Ödemenin Virman Kaydı Oluşturulamadı. Lütfen Kontrol Edip Virman Kaydını Oluşturunuz.</b><table>" +
                                        "<tr><td>Tarih:</td><td>" + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "</td></tr>" +
                                        "<tr><td>Referans No:</td><td>" + result.ReferenceCode + "</td></tr>" +
                                        "<tr><td>Cari Id:</td><td>" + Yetkiler.kullanici.YetkiliOlduguCariIdleri + "</td></tr>" +
                                        "<tr><td>İşlem Yapan Adı:</td><td>" + Yetkiler.kullanici.AdiSoyadi + "</td></tr>" +
                                        "<tr><td>İşlem Yapan Gsm:</td><td>" + Yetkiler.kullanici.Gsm + "</td></tr>" +
                                        "<tr><td>İşlem Yapan Mail:</td><td>" + Yetkiler.kullanici.MailAdresi + "</td></tr>" +
                                        "<tr><td>Hata Mesajı:</td><td>" + aaa.message + "</td></tr>" +
                                        "</table>");
                                    ViewBag.Sonuc += "<tr><td>Durumu:</td><td class='text-danger'><i class='fa-solid fa-triangle-exclamation'></i>Finans Kaydı Oluşturulamadı</td></tr>" +
                              "<tr><td>Cevap:</td><td>" + aaa.message + "</td></tr>";
                                }

                            }
                            else
                            {
                                var aaa = JsonConvert.DeserializeObject<UyumVirmanHataSonucu>(virmanCevabi.Content);

                                ViewBag.Sonuc += "<tr><td>Durumu:</td><td class='text-danger'><i class='fa-solid fa-triangle-exclamation'></i>Finans Kaydı Oluşturulamadı</td></tr>" +
                                "<tr><td>Sonuc:</td><td>" + aaa.responseException.exceptionMessage + "</td></tr>";
                                mail.EksizMailGonderme("mehmettokmak184@gmail.com", "satis@newglobalinsaat.com,info@newglobalinsaat.com", "Virman Oluşturma Hatası",
                                       "<table>" +
                                       "<tr><td>Tarih:</td><td>" + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "</td></tr>" +
                                       "<tr><td>Referans No:</td><td>" + result.ReferenceCode + "</td></tr>" +
                                       "<tr><td>Cari Adi:</td><td>" + Yetkiler.kullanici.YetkiliOlduguCariAdi + "</td></tr>" +
                                       "<tr><td>İşlem Yapan Adı:</td><td>" + Yetkiler.kullanici.AdiSoyadi + "</td></tr>" +
                                       "<tr><td>İşlem Yapan Gsm:</td><td>" + Yetkiler.kullanici.Gsm + "</td></tr>" +
                                       "<tr><td>İşlem Yapan Mail:</td><td>" + Yetkiler.kullanici.MailAdresi + "</td></tr>" +
                                       "<tr><td>Hata Mesajı:</td><td>" + aaa.responseException.exceptionMessage + "</td></tr>" +
                                       "</table>");
                            }
                        }
                      

                        if (siparisDetaylari.BaslikLogicalref != "-1")
                        {
                            var sipOlusturmaDurumu = JsonConvert.DeserializeObject<RestSharp.RestResponse>(sipComplate.SiparisOlustur(siparisDetaylari.BaslikLogicalref, siparisDetaylari.OdemeTipi, siparisDetaylari.ilgiliKisi, siparisDetaylari.tel, siparisDetaylari.detayliAdres, siparisDetaylari.city, siparisDetaylari.towN, siparisDetaylari.siparisAciklamasi, result.ReferenceCode));
                            if (sipOlusturmaDurumu.IsSuccessful)
                            {
                                ViewBag.Sonuc +="<tr><td>Durumu:</td><td class='text-success'><i class='fa-solid fa-check-double'></i>Sipariş Başarıyla Oluşturuldu</td></tr>";
                            }
                            else
                            {
                                ViewBag.Sonuc +="<tr><td>Durumu:</td><td class='text-danger'><i class='fa-solid fa-triangle-exclamation'></i>Sipariş Oluşturulamadı</td></tr>" +
                               "<tr><td>Hata Sebebi:</td><td>" + sipOlusturmaDurumu.Content + "</td></tr>";

                                mail.EksizMailGonderme("mehmettokmak184@gmail.com", "satis@newglobalinsaat.com,info@newglobalinsaat.com", "Sipariş Oluşturma Hatası",
                                 "<b>Sipariş Oluşturulamadı.Lütfen Aşağıda Bilgileri Yazan Bayi İle İletişime Geçiniz.</b><table>" +
                                 "<tr><td>Tarih:</td><td>" + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "</td></tr>" +
                                 "<tr><td>Referans No:</td><td>" + result.ReferenceCode + "</td></tr>" +
                                 "<tr><td>Cari Adi:</td><td>" + Yetkiler.kullanici.YetkiliOlduguCariAdi + "</td></tr>" +
                                 "<tr><td>İşlem Yapan Adı:</td><td>" + Yetkiler.kullanici.AdiSoyadi + "</td></tr>" +
                                 "<tr><td>İşlem Yapan Gsm:</td><td>" + Yetkiler.kullanici.Gsm + "</td></tr>" +
                                 "<tr><td>İşlem Yapan Mail:</td><td>" + Yetkiler.kullanici.MailAdresi + "</td></tr>" +
                                 "<tr><td>Hata Mesajı:</td><td>" + sipOlusturmaDurumu.Content + "</td></tr>" +
                                 "</table>");
                            }
                        }

                    }
                    else
                    {
                        ViewBag.Sonuc +="<tr><td>Durumu:</td><td class='text-danger'><i class='fa-solid fa-triangle-exclamation'></i>İşlem Başarısız</td></tr>" +
                            "<tr><td>Referans Kodu:</td><td>" + result.ReferenceCode + "</td></tr>" +
                            "<tr><td>Banka Cevabı:</td><td>" + result.BankMessage + "</td></tr>" +
                            "<tr><td>Sistem Cevabı:</td><td>" + result.InternalMessage + "</td></tr>";
                    }
                }
                ViewBag.Sonuc += "</table>";
            }
            catch (Exception hata)
            {
                ViewBag.Hata = hata.Message;
            }
            
            return View();
        }

        public SanalPosService.SaleResult OdemeKontrol(string transaction)
        {
            SanalPosService.CommitParameters commit = new SanalPosService.CommitParameters();
            commit.Email = "";
            commit.PaymentGuid = transaction.ToString();
            commit.Phone = "";
            SanalPosService.VendorPaymentServiceClient servis = new SanalPosService.VendorPaymentServiceClient();
            var a = servis.CommitPayment(aut, commit);
            return a;
        }
        [HttpPost]
        public string taksitlerTablosu(string FiyatStr)
        {
            double Fiyat = Convert.ToDouble(FiyatStr.Replace(",", "."));
            SanalPosService.VendorPaymentServiceClient servis = new SanalPosService.VendorPaymentServiceClient();
            var pos = servis.GetVirtualPosList(aut);
           // var aaa = JsonConvert.SerializeObject(pos);
            int enBuyukTaksit = 0;
            foreach (var item in pos)
            {
                foreach (var item2 in item.ComissionRates)
                {
                    enBuyukTaksit = (item2.Instalment > enBuyukTaksit) ? item2.Instalment : enBuyukTaksit;
                }
            }



            string taksitlerHtml = "";
            taksitlerHtml += "<table class='table table-striped table-sm taksitlerTablosu taksitlerTablosuTek' style='width:auto'>";
            taksitlerHtml += "<thead><tr><th></th>";
            foreach (var item in pos)
            {
                if (item.ComissionRates.Where(x => x.Instalment == 1).Count() > 0)
                {
                    taksitlerHtml += "<th style='text-align:center'>" + item.VPosName + "<br/><img style='height:30px' src='/img/" + item.VPosName + ".png' /></th>";
                }
            }
            taksitlerHtml += "</tr></thead>";
            taksitlerHtml += "<tbody>";
            taksitlerHtml += "<tr><td style='border:0.5px solid #adb5bd'>Tek Çekim</td>";
            foreach (var item in pos)
            {
                foreach (var item2 in item.ComissionRates)
                {
                    if (item2.Instalment == 1)
                    {
                        taksitlerHtml += "<td style='border:0.5px solid #adb5bd'>" +
                            "<div class='form-check'>" +
                              "<input style='margin-right:5px' class='form-check-input' type='radio' onchange='TaksitRadioSec(this)' data-PosID='" + item.VPosId + "' data-Taksit='" + item2.Instalment + "' data-KomisyonsuzTutar='" + Fiyat + "' data-KomisyonluTutar='" + Math.Round((Fiyat * Convert.ToDouble(item2.CommRate) + Fiyat), 2) + "' name='flexRadioDefault' id='" + item.VPosId + "_" + item2.Instalment + "'>" +
                              "<label class='form-check-label' for='" + item.VPosId + "_" + item2.Instalment + "'>" +
                                "<small>" + Math.Round((Fiyat * Convert.ToDouble(item2.CommRate) + Fiyat), 2) + " TL</small>" +
                              "</label>" +
                            "</div>" +
                            "</td>";
                    }
                }
            }

            taksitlerHtml += "</tr>";
            taksitlerHtml += "</tbody>";
            taksitlerHtml += "</table>";
            //------------------------------------------------------------------------------------------------------------------------------------------

            taksitlerHtml += "<table class='table table-striped table-sm taksitlerTablosu taksitlerTablosuTaksit' style='width:auto'>";
            taksitlerHtml += "<thead><tr><th></th>";
            foreach (var item in pos)
            {
                if (item.ComissionRates.Where(x => x.Instalment > 1).Count() > 0)
                {
                    taksitlerHtml += "<th style='text-align:center'>" + item.VPosName + "<br/><img style='height:30px' src='/img/" + item.VPosName + ".png' /></th>";
                }

            }
            taksitlerHtml += "</tr></thead>";
            taksitlerHtml += "<tbody>";

            for (int i = 2; i <= enBuyukTaksit; i++)
            {
                taksitlerHtml += "<tr>";
                taksitlerHtml += "<td style='border:0.5px solid #adb5bd'>" + i + " Taksit</td>";
                foreach (var item in pos)
                {
                    var temp = "<td style='border:0.5px solid #adb5bd'></td>";
                    foreach (var item2 in item.ComissionRates)
                    {
                        if (item2.Instalment == i)
                        {
                            temp = "<td style='border:0.5px solid #adb5bd'>" +
                                 "<div class='form-check'>" +
                              "<input style='margin-right:5px'  class='form-check-input' type='radio' onchange='TaksitRadioSec(this)' data-PosID='" + item.VPosId + "' data-Taksit='" + item2.Instalment + "' data-KomisyonsuzTutar='" + Fiyat + "' data-KomisyonluTutar='" + Math.Round((Fiyat * Convert.ToDouble(item2.CommRate) + Fiyat), 2) + "' name='flexRadioDefault' id='" + item.VPosId + "_" + item2.Instalment + "'>" +
                              "<label class='form-check-label' for='" + item.VPosId + "_" + item2.Instalment + "'>" +
                                "<small>" + Math.Round((Fiyat * Convert.ToDouble(item2.CommRate) + Fiyat), 2) + " TL</small>" +
                              "</label>" +
                            "</div>" +
                                "</td>";
                        }
                    }
                    taksitlerHtml += temp;
                }
                taksitlerHtml += "</tr>";
            }



            taksitlerHtml += "</tbody>";
            taksitlerHtml += "</table>";

            return taksitlerHtml;
        }



        [HttpPost]
        public string OdemeYap(string POSID, int taksit, string komisyonluTutar, string komisyonsuzTutar, string kartAdSoyad, string kartNo, string kartTarih, string cvv, string kartTelefon, string Aciklama, string email,
            string BaslikLogicalref, string OdemeTipi, string ilgiliKisi, string tel, string detayliAdres, string city, string towN, string siparisAciklamasi)
        {
            string kartAy = "";
            string kartYil = "";
            var result = new SanalPosService.SaleResult();

            try
            {
                kartNo = kartNo.Replace(" ", "");
                if (taksit == 0)
                {
                    result.IsSuccess = false;
                    result.InternalMessage = "Taksit Sayısı Seçilmelidir!";
                    return JsonConvert.SerializeObject(result);

                }
                if (kartAdSoyad.Trim() == "")
                {
                    result.IsSuccess = false;
                    result.InternalMessage = "Kart Üzerindeki İsim Girilmelidir!";
                    return JsonConvert.SerializeObject(result);

                }
                if (kartNo.Trim() == "")
                {
                    result.IsSuccess = false;
                    result.InternalMessage = "Kart Boş Geçilemez!";
                    return JsonConvert.SerializeObject(result);

                }
                if (kartNo.Trim().Length != 16 || !SayiMi(kartNo))
                {
                    result.IsSuccess = false;
                    result.InternalMessage = "Kart Numarası 16 Hane ve Sayı Olmalıdır! Kart Numarasının Bitişik Olmasına Dikkat Edin!";
                    return JsonConvert.SerializeObject(result);

                }
                if (cvv.Trim() == "")
                {
                    result.IsSuccess = false;
                    result.InternalMessage = "CVV Boş Geçilemez!";
                    return JsonConvert.SerializeObject(result);

                }
                
                if (!kartTarih.Contains("/") || kartTarih.Where(x => x.Equals("/")).Count() > 1)
                {
                    result.IsSuccess = false;
                    result.InternalMessage = "Tarih Formatı Yanlış!";
                    return JsonConvert.SerializeObject(result);

                }
                kartAy = kartTarih.Split('/')[0];
                kartYil = kartTarih.Split('/')[1];

                if (!SayiMi(kartAy) || !SayiMi(kartYil))
                {
                    result.IsSuccess = false;
                    result.InternalMessage = "Tarih Formatı Yanlış!";
                    return JsonConvert.SerializeObject(result);
                }
                if (Convert.ToInt32(kartAy) > 12)
                {
                    result.IsSuccess = false;
                    result.InternalMessage = "Ay 12'den Büyük Olamaz!";
                    return JsonConvert.SerializeObject(result);
                }
                if (Convert.ToInt32(kartYil) < 0 || Convert.ToInt32(kartYil) > 99)
                {
                    result.IsSuccess = false;
                    result.InternalMessage = "Yılın Son 2 Hanesi Yazılmalıdır!";
                    return JsonConvert.SerializeObject(result);
                }
            }
            catch (Exception hata)
            {
                result.IsSuccess = false;
                result.InternalMessage = hata.Message;
                return JsonConvert.SerializeObject(result);
            }

            var siparisDetaylari = new SiparisDetaylari
            {
                BaslikLogicalref = BaslikLogicalref,
                city = city,
                detayliAdres = detayliAdres,
                ilgiliKisi = ilgiliKisi,
                OdemeTipi = OdemeTipi,
                siparisAciklamasi = siparisAciklamasi,
                tel = tel,
                towN = towN,
                tutar= Convert.ToDouble(komisyonsuzTutar)
            };
            SanalPosService.SaleParameters saleParameters = new SanalPosService.SaleParameters();
            saleParameters.Amount = Convert.ToDecimal(komisyonluTutar);
            // saleParameters.BonusId = 1;
            saleParameters.ClientReferenceCode = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            saleParameters.CreditCard = new SanalPosService.CreditCard
            {
                CardHolderName = kartAdSoyad,
                CardNumber = kartNo,
                CvcNumber = cvv,
                Email = email,
                ExpMonth = Convert.ToInt32(kartAy),
                ExpYear = Convert.ToInt32("20" + kartYil),
                Phone = kartTelefon,
                SaveCreditCard = false
            };
            //saleParameters.CreditCard = new SanalPosService.CreditCard
            //{
            //    CardHolderName = "mehmet tokmak",
            //    CardNumber = "4546711234567894",
            //    CvcNumber = "000",
            //    Email = "mail",
            //    ExpMonth = 12,
            //    ExpYear = 2026,
            //    Phone = "5394187423",
            //    SaveCreditCard = false
            //};

            saleParameters.Email = email;
            saleParameters.Installment = taksit;
            saleParameters.ReturnUrl = "https://" + Request.Url.Authority + "/Payment/PaymentResult?resultUrl=" + Aes256CbcEncrypter.Encrypt(JsonConvert.SerializeObject(siparisDetaylari));
            saleParameters.Use3d = true;
            saleParameters.VirtualPosId = Convert.ToInt32(POSID);


            SanalPosService.VendorPaymentServiceClient servis = new SanalPosService.VendorPaymentServiceClient();
            var a = servis.ProcessPayment(aut, saleParameters);
           

            return JsonConvert.SerializeObject(a);

        }

        public bool SayiMi(string text)
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }


        public ActionResult GeneralPayment()
        {
            return View();
        }
    }
}