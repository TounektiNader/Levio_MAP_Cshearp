using Domain.Entities;
using Microsoft.AspNet.Identity;
using ProjetPiMap.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetPiMap.Controllers
{
    public class OfferController : Controller
    {
        IServiceOffer serviceOffer = new ServiceOffer();
        ServiceAdmin serviceAdmin = new ServiceAdmin();
        IServiceJobRequest serviceJob = new ServiceJobRequest();



        // GET: Offer
        public ActionResult Index()
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

        public ActionResult IndexA()
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


        [HttpPost]
        public ActionResult Index(string searchString, int id)
        {

            List<OfferViewModel> lists = new List<OfferViewModel>();
            foreach (var item in serviceOffer.GetAll())
            {
                OfferViewModel OfferViewModel = new OfferViewModel();
                OfferViewModel.JobType = item.JobType;
                OfferViewModel.JobDescription = item.JobDescription;
                OfferViewModel.JobExperience = item.JobExperience;
                OfferViewModel.JobRequirements = item.JobRequirements;
                //OfferViewModel.offerId = item.offerId;
                //OfferViewModel.userId = item.userId;
                OfferViewModel.PostedOn = item.PostedOn;
                OfferViewModel.LastDay = item.LastDay;
                OfferViewModel.ExpectedSalary = item.ExpectedSalary;

                lists.Add(OfferViewModel);

            }
            // return View(lists);
            if (!String.IsNullOrEmpty(searchString))
            {
                lists = lists.Where(m => m.JobType.Contains(searchString)).ToList();
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                lists = lists.Where(m => m.JobDescription.Contains(searchString)).ToList();
            }
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                lists = lists.Where(m => m.offerId == id).ToList();
            }

            return View(lists);
        }


        // GET: Offer/Details/5
        public ActionResult Details(int id)
        {
            List<String> spec = (new List<String> { "Software Engineering", "Graphic Designing", "Front end Developer", "IT Specialist" });
            ViewBag.list = spec;

            OfferJobs offer = serviceOffer.GetById(id);
            BigViewModel bigViewModel = new BigViewModel();


           OfferViewModel offerViewModel = new OfferViewModel();
            offerViewModel.offerId = id;

            offerViewModel.JobType = offer.JobType;
           offerViewModel.JobDescription = offer.JobDescription;
           offerViewModel.JobExperience = offer.JobExperience;
           offerViewModel.JobRequirements = offer.JobRequirements;
           offerViewModel.offerId = offer.offerId;
            //OfferViewModel.userId = item.userId;
           offerViewModel.PostedOn = offer.PostedOn;
           offerViewModel.LastDay = offer.LastDay;
           offerViewModel.ExpectedSalary = offer.ExpectedSalary;
            bigViewModel.offerViewModel = offerViewModel;
            JobRequest jobRequestTest = serviceJob.getJobRequest(User.Identity.GetUserId<int>());

            if (jobRequestTest != null)
            {

                ViewBag.Message = "Vous avez deja inscrit";
                         }
            return View(bigViewModel);

        }

        // GET: Offer/Create
        public ActionResult Create()
        {
            List<String> type = (new List<String> { "Integrator", "Full stack", "Tester", "Network & Security", "Business Intelligence", "Data science", "Data analytics","Big data" });
            ViewBag.list = type;

            List<String> experience = (new List<String> { "More than one year", "More than 2 years", "More than 3 years", "More than 4 years", "More than 5 years" });
            ViewBag.list1 = experience;

            return View();
        }

        // POST: Offer/Create
        [HttpPost]
        public ActionResult Create(OfferViewModel OfferViewModel)
        {
            OfferJobs offer = new OfferJobs();

            List<String> type = (new List<String> { "Integrator", "Full stack", "Tester", "Network & Security", "Business Intelligence", "Data science", "Data analytics" });
            ViewBag.list = type;

            List<String> experience = (new List<String> { "More than one year", "More than 2 years", "More than 3 years", "More than 4 years", "More than 5 years" });
            ViewBag.list1 = experience;

            offer.userId = User.Identity.GetUserId<int>();
            offer.JobType = OfferViewModel.JobType;
            offer.JobDescription = OfferViewModel.JobDescription;
            offer.JobRequirements = OfferViewModel.JobRequirements;
            offer.JobExperience = OfferViewModel.JobExperience;
            offer.ExpectedSalary = OfferViewModel.ExpectedSalary;
            //offer.PostedOn = collection.PostedOn;
            offer.PostedOn = DateTime.Today;
            offer.LastDay = OfferViewModel.LastDay;

            //var dateCreation = DateTime.Now.ToString("dd/MM/yyyy");

            try
            {
                // TODO: Add insert logic here
                serviceOffer.Add(offer);
                serviceOffer.Commit();
                return RedirectToAction("Index", "");
            }
            catch
            {
                return View();
            }
        }

        // GET: Offer/Edit/5
        public ActionResult Edit(int id)
        {
            var offer = serviceOffer.GetById(id);

            OfferViewModel OfferViewModel = new OfferViewModel();

            OfferViewModel.JobType = offer.JobType;
            OfferViewModel.JobDescription = offer.JobDescription;
            OfferViewModel.JobExperience = offer.JobExperience;
            OfferViewModel.JobRequirements = offer.JobRequirements;
            OfferViewModel.offerId = offer.offerId;
            //OfferViewModel.userId = item.userId;
            OfferViewModel.PostedOn = offer.PostedOn;
            OfferViewModel.LastDay = offer.LastDay;
            OfferViewModel.ExpectedSalary = offer.ExpectedSalary;

            var offer1 = serviceOffer.GetAll();
            List<OfferViewModel> List = new List<OfferViewModel>();
            foreach (var item in offer1)
            {
                OfferViewModel OfferViewModel1 = new OfferViewModel();
                
                OfferViewModel1.JobExperience = item.JobExperience;
                OfferViewModel1.JobRequirements = item.JobRequirements;
                //OfferViewModel.offerId = offer.offerId;
                //OfferViewModel.userId = item.userId;
                OfferViewModel1.LastDay = item.LastDay;
                OfferViewModel1.ExpectedSalary = item.ExpectedSalary;

                List.Add(OfferViewModel1);
            }
            
            //ViewData["Biblio"] = new SelectList(List, "BibliothequeCode", "BibliothequeCode");

            return View(OfferViewModel);
        }

        // POST: Offer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OfferViewModel OfferViewModel)
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

        // GET: Offer/Delete/5
        public ActionResult Delete(int id)
        {
            var offre = serviceOffer.GetById(id);

            OfferViewModel OfferViewModel = new OfferViewModel();
            
            OfferViewModel.JobType = offre.JobType;
            OfferViewModel.JobDescription = offre.JobDescription;
            OfferViewModel.JobExperience = offre.JobExperience;
            OfferViewModel.JobRequirements = offre.JobRequirements;
            OfferViewModel.offerId = offre.offerId;
            //OfferViewModel.userId = item.userId;
            OfferViewModel.PostedOn = offre.PostedOn;
            OfferViewModel.LastDay = offre.LastDay;
            OfferViewModel.ExpectedSalary = offre.ExpectedSalary;


            return View(OfferViewModel);
        }

        // POST: Offer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, OfferViewModel OfferViewModel)
        {
            OfferJobs offer = serviceOffer.GetById(id);

            OfferViewModel.offerId = offer.offerId;
            OfferViewModel.JobDescription = offer.JobDescription;
            OfferViewModel.JobExperience = offer.JobExperience;
            OfferViewModel.JobRequirements = offer.JobRequirements;
            OfferViewModel.JobType = offer.JobType;
            OfferViewModel.LastDay = offer.LastDay;
            OfferViewModel.PostedOn = offer.PostedOn;
            OfferViewModel.ExpectedSalary = offer.ExpectedSalary;

            Admin a = serviceAdmin.GetById(id);

            OfferViewModel.userId = offer.userId;

            try
            {
                // TODO: Add delete logic here
                serviceOffer.Delete(offer);
                serviceOffer.Commit();
                return RedirectToAction("Index", "");
            }
            catch
            {
                return View();
            }
        }
    }
}
