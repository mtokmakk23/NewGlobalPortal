using NewGlobalPortal.Models.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace NewGlobalPortal.Models
{
    public class UyumsoftApi
    {
        readonly string KullaniciAdi = "WEBSERVIS";
        readonly string Sifre = "newGlobal@23";
        readonly string PostUrl = "http://api-newglobal.eko.uyumcloud.com:80";
        string token = "";


        string security = "";
        string tokeType = "";
        public UyumsoftApi()
        {

            TokenAl();


        }

        public void TokenAl()
        {
            var db = new Models.NewGlobalDBEntities();
            var tokendb = db.Tokens.Where(x => x.TokenAdi.Equals("UyumToken")).FirstOrDefault();
            if (tokendb == null)
            {
                tokendb = new Token();
                string metodUrl = PostUrl + "/UyumApi/v1/GNL/UyumLogin";
                Uri uri = new Uri(metodUrl);
                var client = new RestClient(uri);
                var request = new RestRequest();
                request.Method = RestSharp.Method.Post;
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(new { Username = KullaniciAdi, Password = Sifre });
                var jsonResponse = client.Execute(request);

                if (!jsonResponse.IsSuccessful)
                {
                    if (jsonResponse.ErrorException != null)
                    {
                        if (!string.IsNullOrWhiteSpace(jsonResponse.ErrorException.Message))
                        {
                            return;
                        }
                    }
                }
                UyumInformation tInfo = JsonConvert.DeserializeObject<UyumInformation>(jsonResponse.Content);
                token = tInfo.result.access_token;
                security = tInfo.result.uyumSecretKey;
                tokeType = tInfo.result.token_type;
                tokendb.OlusmaTarihi = DateTime.Now;
                tokendb.SonGecerlilikTarihi = DateTime.Now.AddHours(1);
                tokendb.Security = security;
                tokendb.Token1 = token;
                tokendb.TokenAdi = "UyumToken";
                tokendb.TokenType = tokeType;
                db.Tokens.Add(tokendb);
                db.SaveChanges();
            }
            else
            {
                if (DateTime.Now > Convert.ToDateTime(tokendb.SonGecerlilikTarihi))
                {
                    string metodUrl = PostUrl + "/UyumApi/v1/GNL/UyumLogin";
                    Uri uri = new Uri(metodUrl);
                    var client = new RestClient(uri);
                    var request = new RestRequest();
                    request.Method = RestSharp.Method.Post;
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(new { Username = KullaniciAdi, Password = Sifre });
                    var jsonResponse = client.Execute(request);

                    if (!jsonResponse.IsSuccessful)
                    {
                        if (jsonResponse.ErrorException != null)
                        {
                            if (!string.IsNullOrWhiteSpace(jsonResponse.ErrorException.Message))
                            {
                                return;
                            }
                        }
                    }
                    UyumInformation tInfo = JsonConvert.DeserializeObject<UyumInformation>(jsonResponse.Content);
                    token = tInfo.result.access_token;
                    security = tInfo.result.uyumSecretKey;
                    tokeType = tInfo.result.token_type;
                    tokendb.OlusmaTarihi = DateTime.Now;
                    tokendb.SonGecerlilikTarihi = DateTime.Now.AddHours(1);
                    tokendb.Security = security;
                    tokendb.Token1 = token;
                    tokendb.TokenType = tokeType;
                    db.SaveChanges();
                }
                else
                {
                    token = tokendb.Token1;
                    security = tokendb.Security;
                    tokeType = tokendb.TokenType;
                }
            }




        }



        public bool teklifGecerlilikTarihiAyarla(string id, string docDate)
        {
            string metodUrl = PostUrl + "/UyumApi/v1/GNL/SaveUyumObjectFromXML";
            Uri uri = new Uri(metodUrl);
            var client = new RestClient(uri);
            var request = new RestRequest();
            request.Method = RestSharp.Method.Post;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", tokeType + " " + token);
            request.AddHeader("UyumSecretKey", security);
            request.AddJsonBody("{\"value\": \"<Uyum Type='PSM.OfferM, PSM' LoadDetail='true'><Id>" + id + "</Id><ValidationDate>" + docDate + "</ValidationDate></Uyum> \"}");
            //  request.AddJsonBody("{\"value\": \"<Uyum Type='PSM.OfferM, PSM' LoadDetail='true'></Uyum> \"}");
            var jsonResponse = client.Execute(request);
            return jsonResponse.IsSuccessful;
        }
        public string TeklifleriGetir(string entitiyId)
        {

            var listItemD = new List<UyumHesapEkstresiResult>();
            var listMaster = new TeklifResult();
            var listOrderM = new List<UyumTeklifMaster>();
            var listOrderD = new List<UyumTeklifDetay>();


            string metodUrl = PostUrl + "/UyumApi/v1/GNL/LoadUyumObjectCollectionFromXML";
            Uri uri = new Uri(metodUrl);
            var client = new RestClient(uri);
            var request = new RestRequest();
            request.Method = RestSharp.Method.Post;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", tokeType + " " + token);
            request.AddHeader("UyumSecretKey", security);
            request.AddJsonBody("{\"value\": \"<Uyum Type='PSM.OfferM, PSM' LoadDetail='true'><EntityCode>" + FiltreliCariGetir(entitiyId).result.entitY_M[0].entityCode + "</EntityCode></Uyum> \"}");
            //  request.AddJsonBody("{\"value\": \"<Uyum Type='PSM.OfferM, PSM' LoadDetail='true'></Uyum> \"}");
            var jsonResponse = client.Execute(request);
            if (jsonResponse.IsSuccessful)
            {
                var UyumTekliflerSonuc = JsonConvert.DeserializeObject<UyumTekliflerSonuc>(jsonResponse.Content);
                if (UyumTekliflerSonuc.statusCode == 200)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(UyumTekliflerSonuc.result);

                    string json = JsonConvert.SerializeXmlNode(doc);

                    if (json.Contains("\"Uyum\":{"))
                    {
                        json = json.Replace("\"Uyum\":{", "\"Uyum\":[{").Replace("}}}", "}]}}");
                    }
                    //   string json = JsonConvert.SerializeObject(table);

                    var result = JsonConvert.DeserializeObject<UyumTeklifler>(json);
                    if (result.UyumCollection != null)
                    {
                        foreach (var item in result.UyumCollection.Uyum)
                        {
                            if (item.ExpireDate == null || item.ExpireDate == "")
                            {
                                if (teklifGecerlilikTarihiAyarla(item.Id, Convert.ToDateTime(item.DocDate).AddDays(1).ToString("yyyy-MM-ddT00:00:00")))
                                {
                                    item.ExpireDate = Convert.ToDateTime(item.DocDate).AddDays(1).ToString("dd.MM.yyyy");
                                }
                            }
                            if (Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy 23:59:59")) < Convert.ToDateTime(item.ExpireDate))
                            {
                                listOrderM.Add(item);
                                var detayString = item.UyumDetailItem.ToString();
                                if (detayString.Substring(0, 1) != "[")
                                {
                                    detayString = "[" + detayString + "]";
                                }
                                var aaaaaaA = JsonConvert.DeserializeObject<List<UyumTeklifDetay>>(detayString);
                                foreach (var item2 in JsonConvert.DeserializeObject<List<UyumTeklifDetay>>(detayString))
                                {
                                    listOrderD.Add(item2);
                                }

                            }


                        }
                    }
                }

            }

            listMaster.UyumMaster = listOrderM.OrderByDescending(x => x.DocDate).ToArray();
            listMaster.UyumDetay = listOrderD.OrderByDescending(x => x.DocDate).ToArray();

            return JsonConvert.SerializeObject(listMaster, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" }).Replace("null", "\"\"");



        }


        public string Cariler()
        {
            var listMaster = new UyumCarilerResult();
            var listOrderM = new List<Entity_M>();
            int i = 1;
            int sayfaSayisi = 0;
            do
            {
                string metodUrl = PostUrl + "/UyumApi/v1/FIN/GetEntity";
                Uri uri = new Uri(metodUrl);
                var client = new RestClient(uri);
                var request = new RestRequest();
                request.Method = RestSharp.Method.Post;
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Authorization", tokeType + " " + token);
                request.AddHeader("UyumSecretKey", security);
                request.AddJsonBody(" { value: { id:0},pageIndex: " + i + ",pageSize: 50}");
                var jsonResponse = client.Execute(request);
                var result = JsonConvert.DeserializeObject<UyumCariler>(jsonResponse.Content);
                sayfaSayisi = result.totalPages;
                foreach (var item in result.result.entitY_M)
                {
                    listOrderM.Add(item);
                }

                i++;
            } while ((i - 1) < sayfaSayisi);
            listMaster.entitY_M = listOrderM.OrderBy(x => x.entityName).ToArray();
            return JsonConvert.SerializeObject(listMaster);
        }

        public UyumCariler FiltreliCariGetir(string id)
        {
            string metodUrl = PostUrl + "/UyumApi/v1/FIN/GetEntity";
            Uri uri = new Uri(metodUrl);
            var client = new RestClient(uri);
            var request = new RestRequest();
            request.Method = RestSharp.Method.Post;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", tokeType + " " + token);
            request.AddHeader("UyumSecretKey", security);
            request.AddJsonBody(" { value: { id:" + id + "}}");
            var jsonResponse = client.Execute(request);
            if (jsonResponse.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<UyumCariler>(jsonResponse.Content);
            }
            else
            {
                return null;
            }


        }


        public string FaturalarBelgesiOlustur(string FaturaNo)
        {
            var result = new RestSharp.RestResponse();
            string metodUrl = PostUrl + "/UyumApi/v1/PSM/GetInvoice";
            Uri uri = new Uri(metodUrl);
            var client = new RestClient(uri);
            var request = new RestRequest();
            request.Method = RestSharp.Method.Post;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", tokeType + " " + token);
            request.AddHeader("UyumSecretKey", security);
            request.AddJsonBody("{\"value\": {\"docNo\":\""+ FaturaNo + "\"}}");
            var jsonResponse = client.Execute(request);

            if (jsonResponse.IsSuccessful)
            {
                var fatura = JsonConvert.DeserializeObject<UyumFaturalar>(jsonResponse.Content);
                if (fatura.statusCode==200)
                {
                    if (fatura.result.invoicE_M.Count()>0)
                    {
                        var htmlBase64 = HtmlBase64Olutur(fatura.result.invoicE_M[0].guID);
                        if (htmlBase64.IsSuccessful)
                        {
                            if (JsonConvert.DeserializeObject<UyumFaturaHtmlResult>(htmlBase64.Content).statusCode==200)
                            {
                                var html = Base64ConvertHtml(JsonConvert.DeserializeObject<UyumFaturaHtmlResult>(htmlBase64.Content).result);
                               
                                result.IsSuccessful = true;
                                result.Content = html;
                            }
                            else
                            {
                                result.IsSuccessful = false;
                                result.ErrorMessage = htmlBase64.ErrorMessage;
                            }
                           
                        }
                        else
                        {
                            result.IsSuccessful = false;
                            result.ErrorMessage = htmlBase64.ErrorMessage;
                        }
                    }
                    else
                    {
                        result.IsSuccessful = false;
                        result.ErrorMessage = "Fatura Belgesi Bulunamadı";
                    }
                    
                  
                }
                else
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = fatura.message;
                }

            }
            else
            {
                result.IsSuccessful = false;
                result.ErrorMessage = jsonResponse.ErrorMessage;
            }
            return JsonConvert.SerializeObject(result);
        }
        public string Base64ConvertHtml(string Base64)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(Base64);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public RestResponse HtmlBase64Olutur(string guID)
        {
            string metodUrl = PostUrl + "/UyumApi/v1/PSM/GetEInvoiceHTML";
            Uri uri = new Uri(metodUrl);
            var client = new RestClient(uri);
            var request = new RestRequest();
            request.Method = RestSharp.Method.Post;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", tokeType + " " + token);
            request.AddHeader("UyumSecretKey", security);
            request.AddJsonBody("{\"value\": {\"ettn\":\"" + guID + "\"}}");
            var jsonResponse = client.Execute(request);
            return jsonResponse;
        }

        public string Siparisler()
        {
            var listMaster = new UyumSiparislerResult();
            var listOrderM = new List<Order_M>();
            var listOrderD = new List<Order_D>();
            int i = 1;
            int sayfaSayisi = 0;
            do
            {
                string metodUrl = PostUrl + "/UyumApi/v1/PSM/GetOrderM";
                Uri uri = new Uri(metodUrl);
                var client = new RestClient(uri);
                var request = new RestRequest();
                request.Method = RestSharp.Method.Post;
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Authorization", tokeType + " " + token);
                request.AddHeader("UyumSecretKey", security);
                request.AddJsonBody(" { value: { id:0, entityId: " + Yetkiler.kullanici.YetkiliOlduguCariIdleri + "},pageIndex: " + i + ",pageSize: 50}");
                var jsonResponse = client.Execute(request);

                if (jsonResponse.IsSuccessful)
                {
                    var result = JsonConvert.DeserializeObject<UyumSiparisler>(jsonResponse.Content, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });
                    sayfaSayisi = result.totalPages;
                    if (result.result.ordeR_M != null)
                        foreach (var item in result.result.ordeR_M)
                        {
                            listOrderM.Add(item);
                        }
                    if (result.result.ordeR_D != null)
                        foreach (var item in result.result.ordeR_D)
                        {
                            listOrderD.Add(item);
                        }

                }
                i++;
            } while ((i - 1) < sayfaSayisi);
            listMaster.ordeR_M = listOrderM.OrderByDescending(x => x.docDate).ToArray();
            listMaster.ordeR_D = listOrderD.OrderByDescending(x => x.docDate).ToArray();

            return JsonConvert.SerializeObject(listMaster, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });


        }

        public string Urunler()
        {


            var listMaster = new List<UyumUrunlerResult>();

            int i = 1;
            int sayfaSayisi = 0;
            do
            {
                string metodUrl = PostUrl + "/UyumApi/v1/INV/GetItemList";
                Uri uri = new Uri(metodUrl);
                var client = new RestClient(uri);
                var request = new RestRequest();
                request.Method = RestSharp.Method.Post;
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Authorization", tokeType + " " + token);
                request.AddHeader("UyumSecretKey", security);
                request.AddJsonBody(" { value: { id:0, branchCode: '" + Yetkiler.parametre.IsYeriKodu + "',DontWants: 'ItemImage' },pageIndex: " + i + ",pageSize: 150}");
                // request.AddJsonBody(" { value: { id:0, branchCode: '"+ Yetkiler.parametre.IsYeriKodu + "' },pageIndex: " + i + ",pageSize: 150}");
                var jsonResponse = client.Execute(request);

                if (jsonResponse.IsSuccessful)
                {
                    var result = JsonConvert.DeserializeObject<UyumUrunler>(jsonResponse.Content);
                    sayfaSayisi = result.totalPages;
                    foreach (var item in result.result)
                    {
                        if (item.itemImageList == null)
                        {
                            item.itemImageList = new string[1];
                            item.itemImageList[0] = "https://bayi.newglobalinsaat.com/Models/UrunResimleri.ashx?id=" + item.id;

                        }

                        foreach (var item2 in item.itemPriceList.Where(x => x.priceListCode.Contains("#")))
                        {
                            if (DateTime.Now < Convert.ToDateTime(item2.endDate))
                            {
                                item2.sonFiyat = (float)Math.Round(item2.unitPriceTra * ((100 - item2.disc1Rate) / 100), 2);

                            }
                            else
                            {
                                item2.sonFiyat = 0;
                            }
                        }
                        listMaster.Add(item);
                    }

                }
                i++;
            } while ((i - 1) < sayfaSayisi);
            return JsonConvert.SerializeObject(listMaster);


        }

        public string FiltreliUrunGetir(string itemCode)
        {

            var listMaster = new List<UyumUrunlerResult>();

            int i = 1;
            int sayfaSayisi = 0;
            do
            {
                string metodUrl = PostUrl + "/UyumApi/v1/INV/GetItemList";
                Uri uri = new Uri(metodUrl);
                var client = new RestClient(uri);
                var request = new RestRequest();
                request.Method = RestSharp.Method.Post;
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Authorization", tokeType + " " + token);
                request.AddHeader("UyumSecretKey", security);
                request.AddJsonBody(" { value: { itemCode:'" + itemCode + "', branchCode: '" + Yetkiler.parametre.IsYeriKodu + "'},pageIndex: " + i + ",pageSize: 50}");
                var jsonResponse = client.Execute(request);

                if (jsonResponse.IsSuccessful)
                {
                    var result = JsonConvert.DeserializeObject<UyumUrunler>(jsonResponse.Content);
                    sayfaSayisi = result.totalPages;
                    foreach (var item in result.result)
                    {
                        if (item.itemCode.ToString() != itemCode)
                        {
                            continue;
                        }

                        foreach (var item2 in item.itemPriceList)
                        {
                            if (DateTime.Now < Convert.ToDateTime(item2.endDate))
                            {
                                item2.sonFiyat = (float)Math.Round(item2.unitPriceTra * ((100 - item2.disc1Rate) / 100), 2);

                            }
                            else
                            {
                                item2.sonFiyat = 0;
                            }
                        }
                        listMaster.Add(item);
                    }

                }
                i++;
            } while ((i - 1) < sayfaSayisi);

            return JsonConvert.SerializeObject(listMaster);

        }



        public string Sehirler()
        {
            string metodUrl = PostUrl + "/UyumApi/v1/GNL/GetTableValues";
            Uri uri = new Uri(metodUrl);
            var client = new RestClient(uri);
            var request = new RestRequest();
            request.Method = RestSharp.Method.Post;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", tokeType + " " + token);
            request.AddHeader("UyumSecretKey", security);
            request.AddJsonBody("{\"value\": {\"tableName\": \"gnld_city\"}}");
            var jsonResponse = client.Execute(request);
            if (jsonResponse.IsSuccessful)
            {
                return jsonResponse.Content;
            }
            return "[]";
        }

        public string SiparisOlustur(string baslikLogicalref, string odemeTipi, string ilgiliKisi, string tel, string detayliAdres, string city, string towN, string siparisAciklamasi, string RefNo)
        {
            var result = new RestSharp.RestResponse();

            try
            {
                var db = new Models.NewGlobalDBEntities();

                var sepetUrunleri = db.SepetIceriks.Where(x => x.BaslikRef.ToString().Equals(baslikLogicalref));
                foreach (var item in sepetUrunleri)
                {
                    if (item.IndirimliFiyat == 0 || item.IndirimliFiyat == null || item.Miktar == 0 || item.Miktar == null)
                    {
                        result.IsSuccessful = false;
                        result.Content = "Fiyatı veya Miktarı 0(Sıfır) Olan Ürünler Sipariş Verilemez.";

                        return JsonConvert.SerializeObject(result);
                    }
                }

                var siparis = new UyumSiparisOlustur();
                if (odemeTipi == "#NK")
                {
                    siparis.paymentMethodId = 27;
                }
                if (odemeTipi == "#KK1")
                {
                    siparis.paymentMethodId = 30;
                }
                if (odemeTipi == "#KKT")
                {
                    siparis.paymentMethodId = 29;
                }
                if (odemeTipi == "#VD")
                {
                    siparis.paymentMethodId = 29;
                }
                if (odemeTipi == "#HV")
                {
                    siparis.paymentMethodId = 31;
                }
                siparis.entityId = Convert.ToInt32(Yetkiler.kullanici.YetkiliOlduguCariIdleri);
                siparis.entityCode = FiltreliCariGetir(Yetkiler.kullanici.YetkiliOlduguCariIdleri).result.entitY_M[0].entityCode;
                siparis.isApproveByMaster = false;
                siparis.orderStatus = "Açık";
                siparis.sourceApp = Yetkiler.parametre.SatisSiparisKaynagi;
                siparis.docTraCode = Yetkiler.parametre.HareketKodu;
                siparis.gnlNote1 = "Siparişi Oluşturan= " + Yetkiler.kullanici.KullaniciAdi + " (" + Yetkiler.kullanici.AdiSoyadi + ")";
                siparis.gnlNote2 = "Virman Fişi DocNo= " + RefNo;
                siparis.shippingAddress1 = ilgiliKisi;
                siparis.shippingAddress2 = tel;
                siparis.shippingAddress3 = detayliAdres;
                siparis.shippingCityId = Convert.ToInt32(city);
                siparis.shippingTownId = Convert.ToInt32(towN);
                siparis.note1 = siparisAciklamasi;
                siparis.branchCode = Yetkiler.parametre.IsYeriKodu;
                siparis.curCode = "TRY";
                siparis.curTra = 1;
                siparis.coCode = Yetkiler.parametre.FirmaKodu;
                siparis.docDate = DateTime.Now;
                siparis.docNo = Yetkiler.parametre.SatisSiparisBelgeNoBaslangici + "-" + (Convert.ToDouble(1 + "" + Yetkiler.parametre.SatisSiparisBaslangicNo.Substring(0, Yetkiler.parametre.SatisSiparisBaslangicNo.Length - 1)) + Convert.ToDouble(baslikLogicalref));
                if (sepetUrunleri.Count() > 0)
                {
                    siparis.details = new NewGlobalPortal.Models.Class.Detail[sepetUrunleri.Count()];
                }
                int sayac = 0;
                foreach (var item in sepetUrunleri)
                {
                    siparis.details[sayac] = new Detail
                    {
                        sourceApp = Yetkiler.parametre.SatisSiparisKaynagi,
                        itemId = Convert.ToInt32(item.UrunId),
                        lineType = "S",
                        qty = Convert.ToInt32(item.Miktar),
                        unitPrice = Convert.ToDouble(item.IndirimsizFiyat),
                        unitPriceTra = Convert.ToDouble(item.IndirimsizFiyat),
                        // disc1Id = 154,//?buradaki 154 ün parametrik olması lazım
                        disc1Rate = Convert.ToInt32(item.IndirimOrani),
                        disc1Code = item.IndirimOraniKodu,
                        vatCode = item.KdvKodu,
                        vatRate = Convert.ToDouble(item.KdvOrani),
                        amtVat = Convert.ToDouble(item.KdvTutari),
                        priceListCode = item.FiyatListesiAdi,
                        priceListId = Convert.ToInt32(item.FiyatListesiId),
                        unitId = Convert.ToInt32(item.BirimKodu),
                        whouseCode = Yetkiler.parametre.DepoKodu,
                        curCode = "TRY",
                        curRateTra = 1,
                        dcardId = Convert.ToInt32(item.UrunId),
                        vatDiscCode = item.TevkifatKodu
                    };

                    sayac++;
                }
                var value = new UyunSiparisValue();
                value.value = siparis;
                string metodUrl = PostUrl + "/UyumApi/v1/PSM/InsertOrderM";
                Uri uri = new Uri(metodUrl);
                var client = new RestClient(uri);
                var request = new RestRequest();
                request.Method = RestSharp.Method.Post;
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Authorization", tokeType + " " + token);
                request.AddHeader("UyumSecretKey", security);
                request.AddJsonBody(JsonConvert.SerializeObject(value));
                var jsonResponse = client.Execute(request);
                if (jsonResponse.IsSuccessful)
                {
                    db.Database.ExecuteSqlCommand("delete from SepetBasligi where LOGICALREF=" + baslikLogicalref);
                    db.Database.ExecuteSqlCommand("delete from SepetIcerik where BaslikRef=" + baslikLogicalref);

                    MailIslemleri mail = new MailIslemleri();
                    mail.EksizMailGonderme("satis@newglobalinsaat.com,info@newglobalinsaat.com,yonetim@newglobalinsaat.com", Yetkiler.kullanici.MailAdresi, "Yeni Sipariş", siparis.docNo + " Numaralı Siparişiniz Tarafımıza Ulaşmıştır.Siparişlerim Ekranında Görebilirsiniz.");
                    result.IsSuccessful = true;
                    result.Content = jsonResponse.Content;
                }
                else
                {
                    result.IsSuccessful = false;
                    result.Content = jsonResponse.Content;
                }


            }
            catch (Exception hata)
            {
                result.IsSuccessful = false;
                result.Content = "{'statusCode':417,'message':'Sipariş Oluşturulamadı: " + hata.Message + "','responseException':{'isError':true,'exceptionMessage':'İskonto1 Kodu Bulunamadı!...'}}";

            }
            return JsonConvert.SerializeObject(result);

        }

        public string TeklifOlustur(string baslikLogicalref, string odemeTipi, string ilgiliKisi, string tel, string detayliAdres, string city, string towN, string siparisAciklamasi)
        {
            var result = new RestSharp.RestResponse();

            try
            {
                var db = new Models.NewGlobalDBEntities();

                var sepetUrunleri = db.SepetIceriks.Where(x => x.BaslikRef.ToString().Equals(baslikLogicalref));
                foreach (var item in sepetUrunleri)
                {
                    if (item.IndirimliFiyat == 0 || item.IndirimliFiyat == null || item.Miktar == 0 || item.Miktar == null)
                    {
                        result.IsSuccessful = false;
                        result.Content = "Fiyatı veya Miktarı 0(Sıfır) Olan Ürünler Sipariş Verilemez.";

                        return JsonConvert.SerializeObject(result);
                    }
                }

                var siparis = new UyumTeklifOlustur();
                if (odemeTipi == "#NK")
                {
                    siparis.paymentMethodId = 27;
                }
                if (odemeTipi == "#KK1")
                {

                    siparis.paymentMethodId = 30;
                }
                if (odemeTipi == "#KKT")
                {
                    siparis.paymentMethodId = 29;
                }
                if (odemeTipi == "#VD")
                {
                    siparis.paymentMethodId = 29;
                }
                if (odemeTipi == "#HV")
                {
                    siparis.paymentMethodId = 31;
                }
                var cariBilgileri = FiltreliCariGetir(Yetkiler.kullanici.YetkiliOlduguCariIdleri);
                siparis.entityId = Convert.ToInt32(Yetkiler.kullanici.YetkiliOlduguCariIdleri);
                siparis.entityCode = cariBilgileri.result.entitY_M[0].entityCode;
                siparis.isApproveByMaster = false;
                siparis.orderStatus = "Açık";
                siparis.sourceApp = Yetkiler.parametre.TeklifKaynagi;
                siparis.docTraCode = Yetkiler.parametre.TeklifHareketKod;
                siparis.gnlNote1 = "Teklifi Oluşturan= " + Yetkiler.kullanici.KullaniciAdi + " (" + Yetkiler.kullanici.AdiSoyadi + ")";
                //siparis.gnlNote2 = "Virman Fişi DocNo= " + RefNo;
                siparis.shippingAddress1 = ilgiliKisi;
                siparis.shippingAddress2 = tel;
                siparis.shippingAddress3 = detayliAdres;
                siparis.shippingCityId = Convert.ToInt32(city);
                siparis.shippingTownId = Convert.ToInt32(towN);
                siparis.note1 = siparisAciklamasi;
                siparis.branchCode = Yetkiler.parametre.IsYeriKodu;
                siparis.curCode = "TRY";
                siparis.curTra = 1;
                siparis.coCode = Yetkiler.parametre.FirmaKodu;
                siparis.docDate = DateTime.Now;
                siparis.expireDate = DateTime.Now.AddDays(1);
                siparis.docNo = Yetkiler.parametre.TeklifBelgeNoBaslangici + "-" + (Convert.ToDouble(1 + "" + Yetkiler.parametre.TeklifBaslangicNo.Substring(0, Yetkiler.parametre.TeklifBaslangicNo.Length - 1)) + Convert.ToDouble(baslikLogicalref));
                if (sepetUrunleri.Count() > 0)
                {
                    siparis.details = new NewGlobalPortal.Models.Class.TeklifDetail[sepetUrunleri.Count()];
                }
                int sayac = 0;
                foreach (var item in sepetUrunleri)
                {
                    siparis.details[sayac] = new TeklifDetail
                    {

                        sourceApp = Yetkiler.parametre.TeklifKaynagi,
                        itemId = Convert.ToInt32(item.UrunId),
                        lineType = "S",
                        qty = Convert.ToInt32(item.Miktar),
                        unitPrice = Convert.ToDouble(item.IndirimsizFiyat),
                        unitPriceTra = Convert.ToDouble(item.IndirimsizFiyat),
                        // disc1Id = 154,//?buradaki 154 ün parametrik olması lazım
                        disc1Rate = Convert.ToInt32(item.IndirimOrani),
                        disc1Code = item.IndirimOraniKodu,
                        vatCode = item.KdvKodu,
                        vatRate = Convert.ToDouble(item.KdvOrani),
                        amtVat = Convert.ToDouble(item.KdvTutari),
                        priceListCode = item.FiyatListesiAdi,
                        priceListId = Convert.ToInt32(item.FiyatListesiId),
                        unitId = Convert.ToInt32(item.BirimKodu),
                        whouseCode = Yetkiler.parametre.DepoKodu,
                        curCode = "TRY",
                        curRateTra = 1,
                        dcardId = Convert.ToInt32(item.UrunId),
                        vatDiscCode = item.TevkifatKodu
                    };

                    sayac++;
                }
                var value = new UyunTeklifValue();
                value.value = siparis;
                string metodUrl = PostUrl + "/UyumApi/v1/PSM/InsertOffer";
                Uri uri = new Uri(metodUrl);
                var client = new RestClient(uri);
                var request = new RestRequest();
                request.Method = RestSharp.Method.Post;
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Authorization", tokeType + " " + token);
                request.AddHeader("UyumSecretKey", security);
                request.AddJsonBody(JsonConvert.SerializeObject(value));
                var jsonResponse = client.Execute(request);
                if (jsonResponse.IsSuccessful)
                {
                    db.Database.ExecuteSqlCommand("delete from SepetBasligi where LOGICALREF=" + baslikLogicalref);
                    db.Database.ExecuteSqlCommand("delete from SepetIcerik where BaslikRef=" + baslikLogicalref);

                    MailIslemleri mail = new MailIslemleri();
                    mail.EksizMailGonderme("satis@newglobalinsaat.com,info@newglobalinsaat.com,yonetim@newglobalinsaat.com", Yetkiler.kullanici.MailAdresi, "Yeni Onay Bekleyen Sipariş", siparis.docNo + " Numaralı Siparişiniz Tarafımıza Ulaşmıştır.Onaylandıktan Sonra Siparişlerim Ekranında Görebilirsiniz.");
                    result.IsSuccessful = true;
                    result.Content = jsonResponse.Content;
                }
                else
                {
                    result.IsSuccessful = false;
                    result.Content = jsonResponse.Content;
                }


            }
            catch (Exception hata)
            {
                result.IsSuccessful = false;
                result.Content = "{'statusCode':417,'message':'Sipariş Oluşturulamadı: " + hata.Message + "','responseException':{'isError':true,'exceptionMessage':'İskonto1 Kodu Bulunamadı!...'}}";

            }
            return JsonConvert.SerializeObject(result);

        }

        public RestResponse VirmanOlustur(double Tutar, string RefNo)
        {
            var db = new Models.NewGlobalDBEntities();
            var virmanBilgileri = new UyumVirmanValue();
            virmanBilgileri.receiptTypeCode = "B2B-VİRMAN";
            virmanBilgileri.amtCredit = Tutar;
            virmanBilgileri.cardCode = "320 01 45 0001";
            virmanBilgileri.coCode = Yetkiler.parametre.FirmaKodu;
            virmanBilgileri.branchCode = Yetkiler.parametre.IsYeriKodu;
            virmanBilgileri.docDate = DateTime.Now;
            //  virmanBilgileri.docNo = "FIN"+DateTime.Now.ToString("yyyyMMddHHmmss");
            virmanBilgileri.sourceApp = "Finans";
            virmanBilgileri.currencyOption = "Sevk_Tarihindeki_Kur";
            virmanBilgileri.docNo = RefNo;
            virmanBilgileri.details = new NewGlobalPortal.Models.Class.UyumVirmanDetail[1];
            virmanBilgileri.details[0] = new UyumVirmanDetail
            {
                traTypeCode = "CARİ ALACAK",
                finDCardId = Convert.ToInt32(Yetkiler.kullanici.YetkiliOlduguCariIdleri),
                amtTra = Tutar,
                amt = Tutar,
                curCode = "TRY",
                curRateTra = 1,
                sourceApp = "Finans"
            };
            string metodUrl = PostUrl + "/UyumApi/v1/FIN/InsertFinance";
            Uri uri = new Uri(metodUrl);
            var client = new RestClient(uri);
            var request = new RestRequest();
            request.Method = RestSharp.Method.Post;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", tokeType + " " + token);
            request.AddHeader("UyumSecretKey", security);
            request.AddJsonBody("{\"value\":" + JsonConvert.SerializeObject(virmanBilgileri) + "}");
            var jsonResponse = client.Execute(request);
            return jsonResponse;

        }
        public string Iceler(string citY_ID)
        {
            string metodUrl = PostUrl + "/UyumApi/v1/GNL/GetDataTableWithSQL";
            Uri uri = new Uri(metodUrl);
            var client = new RestClient(uri);
            var request = new RestRequest();
            request.Method = RestSharp.Method.Post;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", tokeType + " " + token);
            request.AddHeader("UyumSecretKey", security);
            request.AddJsonBody("{\"value\": \"select * from gnld_town where citY_ID= " + citY_ID + "\"}");
            var jsonResponse = client.Execute(request);
            if (jsonResponse.IsSuccessful)
            {
                return jsonResponse.Content;
            }
            return "[]";
        }


        public string Irsaliyeler()
        {
            var listMaster = new UyumIrsaliyelerResult();
            var listItemM = new List<Item_M_M>();
            var listItemD = new List<Item_D>();
            int i = 1;
            int sayfaSayisi = 0;
            do
            {
                string metodUrl = PostUrl + "/UyumApi/v1/INV/GetWaybill";
                Uri uri = new Uri(metodUrl);
                var client = new RestClient(uri);
                var request = new RestRequest();
                request.Method = RestSharp.Method.Post;
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Authorization", tokeType + " " + token);
                request.AddHeader("UyumSecretKey", security);
                request.AddJsonBody("{ value: { id:0},pageIndex: " + i + " ,pageSize: 50}");
                var jsonResponse = client.Execute(request);

                if (jsonResponse.IsSuccessful)
                {
                    var result = JsonConvert.DeserializeObject<UyumIrsaliyeler>(jsonResponse.Content, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });
                    sayfaSayisi = (result.result.iteM_M_M == null) ? -1 : result.result.iteM_M_M.Count();
                    if (result.result.iteM_M_M != null)
                        foreach (var item in result.result.iteM_M_M)
                        {

                            if (item.entityId.ToString() == Yetkiler.kullanici.YetkiliOlduguCariIdleri)
                            {

                                listItemM.Add(item);
                            }

                        }
                    if (result.result.iteM_D != null)
                        foreach (var item in result.result.iteM_D)
                        {

                            if (item.entityId == Yetkiler.kullanici.YetkiliOlduguCariIdleri)
                            {
                                listItemD.Add(item);
                            }

                        }

                }
                i++;
            } while ((i - 1) < sayfaSayisi);
            listMaster.iteM_M_M = listItemM.OrderByDescending(x => x.docDate).ToArray();
            listMaster.iteM_D = listItemD.OrderByDescending(x => x.docDate).ToArray();

            return JsonConvert.SerializeObject(listMaster, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });


        }



        public string HesapEkstresi(string entitiyId)
        {

            var listItemD = new List<UyumHesapEkstresiResult>();



            string metodUrl = PostUrl + "/UyumApi/v1/GNL/GetDataTableWithSQL";
            Uri uri = new Uri(metodUrl);
            var client = new RestClient(uri);
            var request = new RestRequest();
            request.Method = RestSharp.Method.Post;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", tokeType + " " + token);
            request.AddHeader("UyumSecretKey", security);
            request.AddJsonBody("{\"value\": \"select * from WBSERVICE_FIN_EXTRACT WHERE CARI_KOD='" + FiltreliCariGetir(entitiyId).result.entitY_M[0].entityCode + "' \"}");
            var jsonResponse = client.Execute(request);
            if (jsonResponse.IsSuccessful)
            {
                var result = JsonConvert.DeserializeObject<UyumHesapEkstresi>(jsonResponse.Content);
                if (result.result != null)
                {
                    return JsonConvert.SerializeObject(result.result.OrderByDescending(x => x.belgE_TARIH), new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" }).Replace("null", "\"\"");
                }
            }

            return "[]";


        }

        public string UrunResmiDonder(string id)
        {
            var base64 = "";
            string metodUrl = PostUrl + "/UyumApi/v1/INV/GetItemImage";
            Uri uri = new Uri(metodUrl);
            var client = new RestClient(uri);
            var request = new RestRequest();
            request.Method = RestSharp.Method.Post;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", tokeType + " " + token);
            request.AddHeader("UyumSecretKey", security);
            request.AddJsonBody("{\"value\": {\"tIds\": [" + id + "]}}");
            // request.AddJsonBody(" { value: { id:0, branchCode: '"+ Yetkiler.parametre.IsYeriKodu + "' },pageIndex: " + i + ",pageSize: 150}");
            var jsonResponse = client.Execute(request);

            if (jsonResponse.IsSuccessful)
            {
                var sonuc = JsonConvert.DeserializeObject<ImageResult>(jsonResponse.Content);
                if (sonuc.statusCode == 200)
                {
                    foreach (var item in sonuc.result)
                    {
                        base64 = item.image;
                    }
                }
            }
            return base64;
        }

        public string BirimDonusumu(string id, double miktar, string stokKodu, string UrunAdi)
        {

            string metodUrl = PostUrl + "/UyumApi/v1/INV/GetItem";
            Uri uri = new Uri(metodUrl);
            var client = new RestClient(uri);
            var request = new RestRequest();
            request.Method = RestSharp.Method.Post;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", tokeType + " " + token);
            request.AddHeader("UyumSecretKey", security);
            request.AddJsonBody("{\"value\": {\"id\": " + id + "}}");
            var jsonResponse = client.Execute(request);
            if (jsonResponse.IsSuccessful)
            {
                var sonuc = JsonConvert.DeserializeObject<UyumUrunDetaylari>(jsonResponse.Content);
                if (sonuc.statusCode == 200)
                {
                    var sonucStr = "Ürünün Birim Dönüşümü Yapılmamıştır. Lütfen Firmaya Bildiriniz.";
                    foreach (var item in sonuc.result.iteM_UNIT.Where(x => x.unitDesc2.Equals("TAKIM")))
                    {
                        var asd = Convert.ToDouble(item.rate.Replace(",", "."));
                        if (miktar % Convert.ToDouble(item.rate.Replace(",", ".")) == 0)
                        {
                            sonucStr = "OK";
                        }
                        else
                        {
                            sonucStr = Convert.ToDouble(item.rate.Replace(",", ".")) + " ve Katları Kadar Sipariş Verebilirsiniz.";
                        }
                    }
                    if (sonucStr == "Ürünün Birim Dönüşümü Yapılmamıştır. Lütfen Firmaya Bildiriniz.")
                    {
                        MailIslemleri mail = new MailIslemleri();
                        mail.EksizMailGonderme("", "info@newglobalinsaat.com,satis@newglobalinsaat.com", "Birim Dönüşümü Yapılmayan Ürün", stokKodu + " " + UrunAdi + " Ürününün Birim Dönüşümü Yapılmamıştır.Lütfen Birim Dönüşümünü Yapınız Yoksa Bu Ürün Sipariş Çekilemez.");
                    }
                    return sonucStr;
                }
                else
                {
                    return sonuc.message;
                }

            }
            else
            {
                return jsonResponse.ErrorMessage;
            }

        }


























        private class UyumInformation
        {
            public int statusCode { get; set; }
            public string message { get; set; }
            public TokenInfo result { get; set; }
            public ResponseException responseException { get; set; }
        }

        private class TokenInfo
        {
            public string access_token { get; set; }
            public string uyumSecretKey { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
        }

        private class ResponseException
        {
            public bool isError { get; set; }
            public string exceptionMessage { get; set; }
            public object details { get; set; }
            public List<ValidationError> validationErrors { get; set; }
        }
        private class ValidationError
        {
            public string field { get; set; }
            public string message { get; set; }
        }
    }


}