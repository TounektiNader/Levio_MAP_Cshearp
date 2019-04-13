using CrystalDecisions.CrystalReports.Engine;
using Domain.Entities;
using ProjetPiMap.Models;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjetPiMap.Controllers
{
    public class DashboardController : Controller
    {
        IServiceOffer serviceOffer = new ServiceOffer();
        IServiceClient serviceClient = new ServiceCustomer();
        IServiceResources serviceResource = new ServiceResources();
        IServiceUser serviceUser = new ServiceUser();

        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            List<OfferViewModel> lists = new List<OfferViewModel>();
            foreach (var item in serviceOffer.GetAll())
            {
                OfferViewModel OfferViewModel = new OfferViewModel();
                OfferViewModel.JobType = item.JobType;
                OfferViewModel.JobDescription = item.JobDescription;
                OfferViewModel.JobExperience = item.JobExperience;
                OfferViewModel.JobRequirements = item.JobRequirements;
                OfferViewModel.offerId = item.offerId;
                //OfferViewModel.userId = item.userId;
                OfferViewModel.PostedOn = item.PostedOn;
                OfferViewModel.LastDay = item.LastDay;
                OfferViewModel.ExpectedSalary = item.ExpectedSalary;

                lists.Add(OfferViewModel);

            }

            int BigData = lists.Where(x => x.JobType == "Big data").Count();
            int BI = lists.Where(x => x.JobType == "Business Intelligence").Count();
            int DA = lists.Where(x => x.JobType == "Data analytics").Count();
            int DM = lists.Where(x => x.JobType == "Data mining").Count();
            int DS = lists.Where(x => x.JobType == "Data science").Count();
            int FullStack = lists.Where(x => x.JobType == "Full stack").Count();
            int Integrator = lists.Where(x => x.JobType == "Integrator").Count();
            int SN = lists.Where(x => x.JobType == "Network & Security").Count();
            int Tester = lists.Where(x => x.JobType == "Tester").Count();

            Ratio obj = new Ratio();
            obj.BI = BI;
            obj.BigData = BigData;
            obj.DA = DA;
            obj.DM = DM;
            obj.DS = DS;
            obj.SN = SN;
            obj.Tester = Tester;
            obj.FullStack = FullStack;
            obj.Integrator = Integrator;

            return Json(obj, JsonRequestBehavior.AllowGet);

        }

        public class Ratio
        {
            public int BigData { get; set; }
            public int BI { get; set; }
            public int DA { get; set; }
            public int DM { get; set; }
            public int DS { get; set; }
            public int FullStack { get; set; }
            public int Integrator { get; set; }
            public int SN { get; set; }
            public int Tester { get; set; }
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Statistics()
        {
            return View();
        }

        //    public ActionResult StatisticsData()
        //    {
        //        var Em = serviceResource.GetAll();
        //        var A = unit.getRepository<Professeur>().GetAll();
        //        var B = unit.getRepository<Document>().GetAll();

        //        var query = (from i in B
        //                     from k in A
        //                     join l in GetAll() on new { i.DocumentCode, k.AdherantCode } equals new { l.DocumentCode, l.AdherantCode }
        //                     where l.Doc.Etat == Etat.Disponible && l.Date.Year == DateTime.Now.Year
        //                     select l).Count();

        //        ReportDocument rd = new ReportDocument();
        //        rd.Load(System.IO.Path.Combine(Server.MapPath("~/Reports"), "CrystalReport1.rpt"));
        //        rd.SetDataSource(data_);
        //        //rd.SetParameterValue("chemin", Server.MapPath("~/Content/Upload") + "/");
        //        Response.Buffer = false;
        //        Response.ClearContent();
        //        Response.ClearHeaders();

        //        try
        //        {
        //            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //            stream.Seek(0, SeekOrigin.Begin);
        //            return File(stream, "application/pdf", "LetterofEmployement.pdf");
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }

        //    }

        public ActionResult Index1()
        {
            List<ResourcesViewModel> lists = new List<ResourcesViewModel>();
            foreach (var item in serviceResource.GetAll())
            {
                ResourcesViewModel ResourcesViewModel = new ResourcesViewModel();
                ResourcesViewModel.firstname = item.firstname;
                ResourcesViewModel.lastname = item.lastname;
                ResourcesViewModel.address = item.address;
                ResourcesViewModel.Email = item.Email;
                ResourcesViewModel.PhoneNumber = item.PhoneNumber;
                ResourcesViewModel.type = item.type;
                ResourcesViewModel.score = item.score;

                lists.Add(ResourcesViewModel);
            }

            try
            {
                // TODO: Add insert logic here
                return View(lists);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetData1()
        {
            int pigiste = serviceResource.GetAll().Where(x => x.type == "Freelancer").Count();
            int employe = serviceResource.GetAll().Where(x => x.type == "Employee").Count();
            
            Type obj = new Type();
            obj.employe = employe;
            obj.pigiste = pigiste;
            
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public class Type
        {
            public int employe { get; set; }
            public int pigiste { get; set; }
        }

        public ActionResult ExportReport()
        {
            List<ResourcesViewModel> lists = new List<ResourcesViewModel>();
            foreach (var item in serviceResource.GetAll())
            {
                ResourcesViewModel ResourcesViewModel = new ResourcesViewModel();
                ResourcesViewModel.firstname = item.firstname;
                ResourcesViewModel.lastname = item.lastname;
                ResourcesViewModel.address = item.address;
                ResourcesViewModel.Email = item.Email;
                ResourcesViewModel.PhoneNumber = item.PhoneNumber;
                ResourcesViewModel.type = item.type;
                ResourcesViewModel.score = item.score;

                lists.Add(ResourcesViewModel);
            }

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "EmployeevsFreelancer.rpt"));
            rd.SetDataSource(lists);
            //rd.SetDataSource("Rania");
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "EmployeevsFreelancer.pdf");
            }
            catch (Exception ex)
            {
                throw;
                //return View("IndexA","Offer");
            }
        }

    }
}
