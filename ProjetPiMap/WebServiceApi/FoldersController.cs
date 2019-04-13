using Data;
using Domain.Entities;
using Microsoft.AspNet.Identity.Owin;
using ProjetPiMap.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProjetPiMap.WebServiceApi
{
    public class FoldersController : ApiController
    {
        private Context db = new Context();
        public static IServiceOffer cs;
       public static  IServiceJobRequest serviceJob;
        public static IServiceFolder serviceFolder;



        public FoldersController()
        {
            cs = new ServiceOffer();
            serviceJob = new ServiceJobRequest();
            serviceFolder = new ServiceFolder();

            //    cs = new ServiceTest();
        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public FoldersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
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
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }





        public IEnumerable<OfferModel> GetFolders()
        {

            OfferModel OfferViewModel = new OfferModel();


            List<OfferModel> lists = new List<OfferModel>();
            
            var tests = cs.GetAll();
            List<OfferModel> lpm = new List<OfferModel>();
            foreach (var item in tests)

                lpm.Add(
                        new OfferModel
                        {

                            JobType = item.JobType,
                            JobDescription = item.JobDescription,
                            JobExperience = item.JobExperience,
                            JobRequirements = item.JobRequirements,
                            offerId = item.offerId,
                          //OfferViewModel.userId = item.userId;
                            PostedOn = serviceJob.GetAll().Where(a => a.offerId == item.offerId).Count().ToString(),
                            LastDay = item.LastDay,
                            ExpectedSalary = item.ExpectedSalary,
                            userId = serviceJob.GetAll().Where(a => a.offerId == item.offerId).Count(),

         

        });
            return lpm;
        }



        [ResponseType(typeof(Folder))]
        public IHttpActionResult GetFolder(int id)
        {
            JobRequest jobrequest = serviceJob.GetAll().Where(a => a.userId == id).SingleOrDefault();
            Folder folder = serviceFolder.GetAll().Where(a => a.jobRequestId == jobrequest.jobRequestId).SingleOrDefault();

            FolderViewModel folerModel = new FolderViewModel();
            folerModel.folderId = folder.folderId;
            folerModel.typeTest = folder.typeTest;
            folerModel.testResult = folder.testResult;
            folerModel.state = folder.state;
            folerModel.etape = folder.etape;




            if (folder == null)
            {
                return NotFound();
            }

            return Ok(folerModel);
        }

    }
}
