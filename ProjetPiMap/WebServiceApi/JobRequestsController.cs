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
    public class JobRequestsController : ApiController
    {

        private Context db = new Context();
        public static IServiceJobRequest cs;
        public static IServiceFolder serviceFolder;

        public JobRequestsController()
        {
            cs = new ServiceJobRequest();
            serviceFolder = new ServiceFolder();

            //    cs = new ServiceTest();
        }


        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        private ApplicationRoleManager _roleManager;


        public JobRequestsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;

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





        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }




        public IEnumerable<JobModel> GetUsers(int id)
        {
            List<JobModel> lpm = new List<JobModel>();
            List<Folder> folders = new List<Folder>();
            List<JobRequest> jobs = new List<JobRequest>();


            folders = serviceFolder.GetAll().Where(a => a.etape == 3).ToList();


            foreach (var item in folders)
            {
                
                jobs = cs.GetAll().Where(a=>a.offerId == id ).ToList();


            }

            foreach (var item in jobs)
            {

                JobModel jobModel = new JobModel();
                jobModel.dateApply = item.userId;
                jobModel.speciality = item.speciality;
                jobModel.userId = item.userId;
                jobModel.jobRequestId = item.jobRequestId;
                jobModel.state = item.state;

                lpm.Add(jobModel);
            }


            return lpm;

        }


        [HttpGet]
        [Route("JobRequests/GetJobAssign")]
        [ResponseType(typeof(JobRequest))]
        public IEnumerable<JobModel> GetJobAssign(int id)
        {
            List<JobModel> lpm = new List<JobModel>();
            List<Folder> folders = new List<Folder>();
            List<JobRequest> jobs = new List<JobRequest>();


            folders = serviceFolder.GetAll().Where(a => a.etape == 3).ToList();


            foreach (var item in folders)
            {
                jobs = cs.GetAll().Where(a => a.offerId == id).ToList();


            }

            foreach (var item in jobs)
            {

                JobModel jobModel = new JobModel();
                jobModel.dateApply = item.userId;
                jobModel.speciality = item.speciality;
                jobModel.userId = item.userId;
                jobModel.jobRequestId = item.jobRequestId;
                jobModel.state = "Assign";

                lpm.Add(jobModel);
            }


            return lpm;

        }




    }
}
