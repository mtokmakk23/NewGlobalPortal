using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace NewGlobalPortal.Models
{
    /// <summary>
    /// Summary description for UrunResimleri
    /// </summary>
    public class UrunResimleri : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Byte[] bytdizi = new Byte[-1 + 1];
            context.Response.ContentType = "text/plain";
            var id = context.Request.QueryString["id"];
            // context.Response.Write("/img/urun-resim-yok.png");
            UyumsoftApi api = new UyumsoftApi();
            var imageBase64 = api.UrunResmiDonder(id);
            if (imageBase64=="")
            {
                imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAP8AAAD/CAYAAAA+CADKAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAADImlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS4zLWMwMTEgNjYuMTQ1NjYxLCAyMDEyLzAyLzA2LTE0OjU2OjI3ICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M2IChXaW5kb3dzKSIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo2M0E3MENDOUMyRTcxMUUyOEQwQ0IyMUU5QkFGREFGMyIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDo2M0E3MENDQUMyRTcxMUUyOEQwQ0IyMUU5QkFGREFGMyI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOjYzQTcwQ0M3QzJFNzExRTI4RDBDQjIxRTlCQUZEQUYzIiBzdFJlZjpkb2N1bWVudElEPSJ4bXAuZGlkOjYzQTcwQ0M4QzJFNzExRTI4RDBDQjIxRTlCQUZEQUYzIi8+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwv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d+utau3vBYlfiECRDytEoEj8QgSKxC9EoEj8QgSKxC9EoEj8QgSKxC9EoEj8QgSKxC9EoEj8QgSKxC9EoEj8QgSKxC9EoEj8QgSKxC9EoEj8QgSKxC9EoEj8QgSKxC9EoEj8QgSKxC9EoEj8QgSKxC9EoGjd/iygurra9u7da6dOnfJvDBo6dKjNmjXrY28PampqsqNHj1plZaV/ucjx48dt5MiRVlpamjhiYGhubrbt27dbZ2enXXfddT7snXfesby8PLvyyiutqKjIh4l4Icsfc1atWmV//OMf7fXXX7etW7fae++9Z6+++qr97ne/s4MHDyaO6qKqqsp+//vf265du2z//v3+O58DTWNjo0/nypUrEyFmK1assNdee83vE/Ek9/86Et9FzHj77bftjTfesBEjRtjcuXPtpptusilTpnirjqgR/7Rp07yFBZw4vl911VXeO+D1YhMnTrSysjK/f6DA8m/ZssWf/4YbbvBhnP/yyy+3UaNG+XSI+CHLH1NOnz5tGzdu9N/vvfdemzNnjl1yySU2efJku+uuu7y4cPvr6+v9MUAhMXbsWFu9erX3FDh29OjRib1mtbW13hofOHDAexDPPvusnTx50u9bt26d/eMf/7BnnnnGli9f7o/tzoYNG+zvf/+7vfjii+fcn0xDQ4OvhlAVEPFEdf6YglX/85//bNdee63dfffdidCeaW9vtz/96U9WU1NjFRUV1tHR4YU9YcIEe+CBB/wxeAt/+ctf/H4Kjba2NvvWt75lixcv9sdSeOBVEAf7OC/WGyFTKERtCGfOnPHCvuOOO3z6KAiefPJJn4bvfOc7/lw/+9nPrLCw0L72ta/ZsGHDfJiIF7L8MeXEiRNeiIgtorW11det165d6zcsfGS5aQfgN1QPHnnkEXv00UdtxowZtm/fPn8sEF9BQYEX8+c//3kvbkT8wQcf2PDhw+3BBx+0r3/963bPPff46kTUoIhLT2F066232sMPP2yPPfaYF/b69et9ms712nKqH2ycU8QTiT/mIK6IlpYWe+mllz5sTHvllVe84LHyx44ds+LiYps5c2biaLOpU6daSUmJd/MBIeKGI3SOw2qPGTPGixfrTcPiU089ZYcPH7bbbrvNVxuAlnzETt2dRkfi41z0LFCQnEvghEn48Ubijym46/n5+bZnz55EiHkhY3mxzrjjWFYE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";
            }
            var img = Base64StringToBitmap(imageBase64);
            bytdizi = (Byte[])imageToByteArray(img);
            System.IO.Stream ms = new System.IO.MemoryStream(bytdizi);

            byte[] buffer = new byte[4096];
            int byteSeq = ms.Read(buffer, 0, 4096);

            HttpContext.Current.Response.ContentType = "image/png";
            while (byteSeq > 0)
            {

                HttpContext.Current.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = ms.Read(buffer, 0, 4096);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
       
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(imageIn);
                bmp.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public static Bitmap Base64StringToBitmap(string base64String)
        {
            Bitmap bmpReturn = null;


            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);


            memoryStream.Position = 0;


            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);


            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;


            return bmpReturn;
        }
    }
}