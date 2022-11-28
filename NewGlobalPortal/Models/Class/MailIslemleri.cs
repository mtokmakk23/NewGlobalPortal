using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace NewGlobalPortal.Models.Class
{
    public class MailIslemleri
    {
        string mesajGonderecekMail = "sistem@newglobalinsaat.com";
        string mailAdi = "New Global Sistem";
        string MesajSifresi = "NewGlobalSistem23";
        public bool EkliMailGonderme(string Bilgi, string Alici, string Konu, string Icerik, byte[] DosyaByte, string UzantiliSekildeDosyaAdi)
        {
            try
            {
                MailMessage mesaj = new MailMessage();
                mesaj.From = new MailAddress(mesajGonderecekMail, mailAdi);

                if (Bilgi.Trim() != "")
                {
                    if (Bilgi[Bilgi.Length - 1].ToString() != ",")
                    {
                        Bilgi = Bilgi + ",";
                    }
                    var bccString = Bilgi.Split(',');
                    for (int i = 0; i < bccString.Length - 1; i++)
                    {
                        mesaj.Bcc.Add(bccString[i]);
                    }
                }

                if (Alici.Trim() != "")
                {

                    if (Alici[Alici.Length - 1].ToString() != ",")
                    {
                        Alici = Alici + ",";
                    }
                    var toString = Alici.Split(',');
                    for (int i = 0; i < toString.Length - 1; i++)
                    {
                        mesaj.To.Add(toString[i]);
                    }

                }


                mesaj.Subject = Konu;
                mesaj.IsBodyHtml = true;
                mesaj.Body = Icerik;


                Attachment at = new Attachment(new MemoryStream(DosyaByte), UzantiliSekildeDosyaAdi);
                mesaj.Attachments.Add(at);
                mesaj.IsBodyHtml = true; // giden mailin içeriği html olmasını istiyorsak true kalması lazım
                SmtpClient client = new SmtpClient("mail.newglobalinsaat.com", 587);
                client.Credentials = new NetworkCredential(mesajGonderecekMail, MesajSifresi);
                client.EnableSsl = false;
                client.Send(mesaj);

                at.Dispose();
                return true;
            }
            catch (Exception)
            {
               
                return false;
            }

        }

        public bool EksizMailGonderme(string Bilgi, string Alici, string Konu, string Icerik)
        {
            try
            {
                MailMessage mesaj = new MailMessage();
                mesaj.From = new MailAddress(mesajGonderecekMail, mailAdi);

                //  mesaj.Bcc.Add("mehmettokmak@hausport.com");
                if (Bilgi.Trim() != "")
                {
                    if (Bilgi[Bilgi.Length - 1].ToString() != ",")
                    {
                        Bilgi = Bilgi + ",";
                    }
                    var bccString = Bilgi.Split(',');
                    for (int i = 0; i < bccString.Length - 1; i++)
                    {
                        mesaj.Bcc.Add(bccString[i]);
                    }
                }


                if (Alici.Trim() != "")
                {

                    if (Alici[Alici.Length - 1].ToString() != ",")
                    {
                        Alici = Alici + ",";
                    }
                    var toString = Alici.Split(',');
                    for (int i = 0; i < toString.Length - 1; i++)
                    {
                        mesaj.To.Add(toString[i]);
                    }

                }


                mesaj.Subject = Konu;
                mesaj.IsBodyHtml = true;
                mesaj.Body = Icerik;



                mesaj.IsBodyHtml = true; // giden mailin içeriği html olmasını istiyorsak true kalması lazım
                SmtpClient client = new SmtpClient("mail.newglobalinsaat.com", 587);
                //client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(mesajGonderecekMail, MesajSifresi);
                client.EnableSsl = false;
                client.Send(mesaj);

                return true;
            }
            catch (Exception hata)
            {
               
                return false;
            }

        }
    }
}