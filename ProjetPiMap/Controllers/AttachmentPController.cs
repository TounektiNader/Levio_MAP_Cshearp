using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gnostice.StarDocsSDK;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ProjetPiMap.Controllers
{
    public class AttachmentPController : Controller
    {
        // GET: AttachmentP
        public ActionResult Display(string attachment)
        {
            //create viewer for document on server
            string file = @"C:/Users/Nader/Documents/GitHub/Map2018PI/Map2018IConsult/ProjetPiMap/UploadAttachment/"+attachment;
            ViewerSettings viewerSettings = new ViewerSettings();
            viewerSettings.VisibleFileOperationControls.Open = true;
            ViewResponse viwerResponse = MvcApplication.starDocs.Viewer.CreateView(
                new FileObject(file), null, viewerSettings);
            return new RedirectResult(viwerResponse.Url);
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string qrcode)
        {
            
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    ViewBag.QRCodeImage = "data: image / png; base64," + Convert.ToBase64String(ms.ToArray());
            
                }
            }

            return View();
        }
    }
}