using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProjetPiMap.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjetPiMap.Controllers
{
    public class FolderController : Controller
    {
        IServiceAttachment serviceAttachment = new ServiceAttachment();
        IServiceFolder serviceFolder = new ServiceFolder();
        IServiceJobRequest serviceJobRequest = new ServiceJobRequest();



        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;



        public FolderController()
        {
        }

        public FolderController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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




        // GET: Folder
        [Authorize(Roles = "Resource")]
        public async Task<ActionResult> Index()
        {
            BigViewModel big = new BigViewModel();

            //get details  user Connec


            string username = User.Identity.GetUserName();
            User user = await UserManager.FindByEmailAsync(username);

            UserModel model = new UserModel();
            model.userId = user.Id;
            model.address = user.address;
           
            model.Email = user.Email;
            model.firstname = user.firstname;
            model.lastname = user.lastname;
            model.phoneNumber = user.PhoneNumber;
            big.resourceViewModel = model;

            //////////////////////

            JobRequest jobrequest = serviceJobRequest.GetAll().Where(a => a.userId == User.Identity.GetUserId<int>()).SingleOrDefault();
            Folder folder = serviceFolder.GetAll().Where(a => a.jobRequestId == jobrequest.jobRequestId).SingleOrDefault();
            FolderViewModel folerModel = new FolderViewModel();
            folerModel.folderId = folder.folderId;
            folerModel.typeTest = folder.typeTest;
            folerModel.testResult = folder.testResult;
            folerModel.state = folder.state;
            folerModel.etape = folder.etape;

            big.folderViewModel = folerModel;

            return View(big);
        }


        public ActionResult Assigner(int idJobRequest,int idUser)
        {
            JobRequest jobrequest = serviceJobRequest.GetAll().Where(a => a.jobRequestId == idJobRequest && a.userId == idUser).SingleOrDefault();

            Folder folder = serviceFolder.GetAll().Where(a => a.jobRequestId == idJobRequest).SingleOrDefault();

            folder.state = "Assign";
            folder.etape = 4;
            serviceFolder.Update(folder);
            serviceFolder.Commit();

           return RedirectToAction("listOffers", "JobRequest");
        }

        // GET: Folder/Details/5
        public ActionResult Details(int id)
        {

          

            return View();
        }

        // GET: Folder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Folder/Create
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

        // GET: Folder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Folder/Edit/5
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

        // GET: Folder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Folder/Delete/5
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
    }
}
