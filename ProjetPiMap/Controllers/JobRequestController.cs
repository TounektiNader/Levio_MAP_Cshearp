using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProjetPiMap.Models;
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
    public class JobRequestController : Controller
    {


        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public JobRequestController()
        {
        }

        public JobRequestController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
          
        }

     

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        

        IServiceJobRequest serviceJob = new ServiceJobRequest();
        IServiceFolder serviceFolder = new ServiceFolder();
        IServiceAttachment serviceAttachment = new ServiceAttachment();
        IServiceOffer serviceOffer = new ServiceOffer();
        IServiceUser serviceUser = new ServiceUser();
        IServiceResources serviceResouce = new ServiceResources();


        String message;


        // GET: JobRequest

        public ActionResult Index()
        {
            List<JobRequestModel> list = new List<JobRequestModel>();
            foreach (var item in serviceJob.GetAll())
            {
                JobRequestModel fv = new JobRequestModel();
                fv.userId = item.userId;
                fv.state = item.state;
                fv.speciality = item.speciality;
                fv.dateApply = item.dateApply;
                fv.jobRequestId = item.jobRequestId;

                list.Add(fv);
            }
            ViewBag.Message = message;
            return View(list);
        }



        [HttpPost]
        public ActionResult Indexx(string searchString)
        {
            List<JobRequestModel> list = new List<JobRequestModel>();
            foreach (var item in serviceJob.GetAll())
            {
                JobRequestModel fv = new JobRequestModel();
                fv.userId = item.userId;
                fv.state = item.state;
                fv.speciality = item.speciality;
                fv.dateApply = item.dateApply;
                fv.jobRequestId = item.jobRequestId;

                list.Add(fv);
            }
            if (!String.IsNullOrEmpty(searchString))
            {

                list = list.Where(a => a.speciality.Contains(searchString)).ToList();
            }

            return View(list);
        }



        public ActionResult jobOffer(int id)
        {
            List<JobRequestModel> list = new List<JobRequestModel>();
            foreach (var item in serviceJob.GetAll().Where(a=>a.offerId==id))
            {
                JobRequestModel fv = new JobRequestModel();
                fv.userId = item.userId;
                fv.state = item.state;
                fv.speciality = item.speciality;
                fv.dateApply = item.dateApply;
                fv.jobRequestId = item.jobRequestId;

                list.Add(fv);
            }
            return View(list);
        }

        // GET: JobRequest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
      
        // GET: JobRequest/Create
        public ActionResult Create()
        {

            List<String> spec = (new List<String> { "Software Engineering", "Graphic Designing", "Front end Developer", "IT Specialist" });
            ViewBag.list = spec;

            return View();
        }

       
        // POST: JobRequest/Create
        [HttpPost]
        public ActionResult Create(BigViewModel bigViewModel,HttpPostedFileBase file,int idOffer)
        {
            List<String> spec = (new List<String> { "Software Engineering", "Graphic Designing", "Front end Developer", "IT Specialist" });
            ViewBag.list = spec;

            JobRequest job = new JobRequest();
            job.speciality = bigViewModel.jobRequestModel.speciality;
            //job.dateApply = bigViewModel.jobRequestModel.dateApply;
            job.dateApply = DateTime.Now;

            job.state = "Pending";          
            job.userId = User.Identity.GetUserId<int>();
            job.offerId = idOffer;

            JobRequest jobRequestTest = serviceJob.getJobRequest(User.Identity.GetUserId<int>());

            if ( jobRequestTest != null) {

                ViewBag.Message = "Vous avez deja inscrit";
                return RedirectToAction("Details", "Offer",new { id = idOffer });
            }

            else { 

                serviceJob.Add(job);
                serviceJob.Commit();

                JobRequest getJob =serviceJob.getJobRequest(job.userId, 1);

                Folder folder = new Folder();
                Attachment attachment = new Attachment();
                folder.state = "New Job Request";
                folder.jobRequestId = getJob.jobRequestId;
                folder.etape = 0;

                serviceFolder.Add(folder);
                serviceFolder.Commit();

               // Folder getFolder = serviceFolder.getFolder(getJob);

                attachment.folderId = folder.folderId;
                attachment.typeAttachment = "CV";
                attachment.proved = "Pending";
               
            if(file==null)
            {
                ModelState.AddModelError(bigViewModel.attachmentModel.lienAttachment, "Please Select CV");
                return View();
                
            }
            if (!(file.ContentType== "application/vnd.openxmlformats-officedocument.wordprocessingml.document”" || file.ContentType=="application/pdf"))
            {
                ModelState.AddModelError(bigViewModel.attachmentModel.lienAttachment, "Only .docs and .pdf file  allowed");
                return View();
            }

            if (ModelState.IsValid)
            {
                try {
                    String fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    file.SaveAs(Path.Combine(Server.MapPath("~/UploadAttachment"), fileName));
                    attachment.lienAttachment = fileName;
                    serviceAttachment.Add(attachment);
                    serviceAttachment.Commit();
                    ViewBag.Message = "Successufuly Done";
                } catch { ViewBag.Message = "Error Please try  again !!"; }
               
                
            }





                return RedirectToAction("Index","Folder");
            }
        }

        // GET: JobRequest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobRequest/Edit/5
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

        // GET: JobRequest/Delete/5
        public ActionResult Delete(int id)
        {
            JobRequest jobRequest = new JobRequest();
            jobRequest = serviceJob.GetById(id);

            Folder folder = new Folder();
            folder = serviceFolder.getFolder(jobRequest.jobRequestId);

            List <Attachment> attachments= new List <Attachment>();
            attachments = serviceAttachment.GetAll().Where(a => a.folderId == folder.folderId).ToList();
            foreach(var item in attachments)
            {
                serviceAttachment.Delete(item);
                serviceAttachment.Commit();


            }

            serviceFolder.Delete(folder);
            serviceFolder.Commit();

            serviceJob.Delete(jobRequest);
            serviceJob.Commit();
            message = "The Job Request was removed with successfully";
            return RedirectToAction("Index","JobRequest");

           
        }

        // POST: JobRequest/Delete/5
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
        public ActionResult partialModal() {
            return View();
                }

        [HttpPost]
        public ActionResult partialModal(IndexViewModel odn)
        {
            return View();
        }

        public ActionResult listOffers()
        {

          
         
            List<OfferViewModel> lists = new List<OfferViewModel>();
            foreach (var item in serviceOffer.GetAll())
            {

                int c = serviceJob.GetAll().Where(a => a.offerId == item.offerId).Count();
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
                OfferViewModel.userId = c;

                lists.Add(OfferViewModel);
            }
            return View(lists);}

        public async Task<ActionResult> UsersByOffer(int id)
        {
            
            List<BigViewModel> list = new List<BigViewModel>();
            List<Folder> folders = new List<Folder>();
            List<JobRequest> jobs = new List<JobRequest>();
            folders = serviceFolder.GetAll().Where(a => a.etape == 3).ToList();

            foreach(var item in folders)
            {
                jobs=serviceJob.GetAll().Where(a => a.offerId == id && a.jobRequestId == item.jobRequestId).ToList();


            }

            foreach (var item in jobs)
            {


                User user = await UserManager.FindByIdAsync(item.userId);

                UserModel userModel = new UserModel();
                userModel.firstname = user.firstname;
                userModel.lastname = user.lastname;
                userModel.Email = user.Email;
                userModel.userId = user.Id;


              JobRequestModel jobModel = new JobRequestModel();
                jobModel.dateApply = item.dateApply;
                jobModel.speciality = item.speciality;
                jobModel.userId = item.userId;
                jobModel.jobRequestId = item.jobRequestId;
                jobModel.state = item.state;

                //   Resource user1 = serviceResouce.getResource(user.UserName);

              


                BigViewModel bg = new BigViewModel();
                
                bg.resourceViewModel = userModel;
              

                bg.jobRequestModel = jobModel;
                
                list.Add(bg);
            }
            return View(list);
        }

        


    }
}
