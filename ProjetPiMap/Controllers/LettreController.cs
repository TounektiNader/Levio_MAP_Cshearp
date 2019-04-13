using CrystalDecisions.CrystalReports.Engine;
using Domain.Entities;
using iTextSharp.text.pdf.parser;
using Microsoft.AspNet.Identity;
using ProjetPiMap.Models;
using ProjetPiMap.Report;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjetPiMap.Controllers
{
    public class LettreController : Controller
    {
        IServiceUser us = new ServiceUser();
        IServiceTest serviceTest = new ServiceTest();
        // GET: Lettre
        public ActionResult Report()
        {
            List<Test> tests = serviceTest.GetAll().ToList();
            LettreReport lettre = new LettreReport();
            byte[] abytes = lettre.PrepareReport(tests);

            return File(abytes,"application/pdf");
        }

        public ActionResult ExportReport(string username)
        {
            
            var data_ = us.GetAll().Where(x => x.UserName == username)
                .Select(x => new {
                    x.firstname,
                    x.address,
                    x.lastname,
                    x.Email,
                    x.PhoneNumber
                }).ToList();

            ReportDocument rd = new ReportDocument();
            rd.Load(System.IO.Path.Combine(Server.MapPath("~/Report"), "Letter.rpt"));
            rd.SetDataSource(data_);
            //rd.SetParameterValue("chemin", Server.MapPath("~/Content/Upload") + "/");
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "LetterofEmployement.pdf");
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public ActionResult LetterEmployement()
        {
            return View();
        }

    }
}