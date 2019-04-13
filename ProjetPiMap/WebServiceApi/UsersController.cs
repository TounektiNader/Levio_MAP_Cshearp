using Data;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using ProjetPiMap.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProjetPiMap.WebServiceApi
{
    public class UsersController : ApiController
    {
        private Context db = new Context();
        public static IServiceUser cs;

        public UsersController()
        {
            cs = new ServiceUser();

            //    cs = new ServiceTest();
        }


        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        private ApplicationRoleManager _roleManager;


        public UsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager,ApplicationRoleManager roleManager)
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


        public IEnumerable<UserApiModel> GetUsers()
        {
            var tests = cs.GetAll();
            List<UserApiModel> lpm = new List<UserApiModel>();
            foreach (var item in tests)
                lpm.Add(new UserApiModel
                {
                    id = item.Id,
                    email = item.Email,
                    firstname = item.firstname,
                    lastname = item.lastname,
                    address = item.address,
                    phoneNumber = item.PhoneNumber,
                    motDePasse =item.motDePasse,
                    //role = await RoleManager.FindByIdAsync(item.Roles.FirstOrDefault().RoleId).name
                    


                });
            return lpm;

        }



        // GET: api/Tests/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetResource(int id)
        {
            User user = await UserManager.FindByIdAsync(id);

            UserApiModel userModel = new UserApiModel();
            userModel.firstname = user.firstname;
            userModel.lastname = user.lastname;
            userModel.email = user.Email;
            userModel.id = user.Id;
            var role = await RoleManager.FindByIdAsync(user.Roles.FirstOrDefault().RoleId);

           
            userModel.role = role.Name;
            


            if (user == null)
            {
                return NotFound();
            }

            return Ok(userModel);
        }



        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(String email)
        {
            User user = await UserManager.FindByEmailAsync(email);

            UserApiModel userModel = new UserApiModel();
            userModel.firstname = user.firstname;
            userModel.lastname = user.lastname;
            userModel.email = user.Email;
            userModel.id = user.Id;
            var role = await RoleManager.FindByIdAsync(user.Roles.FirstOrDefault().RoleId);


            userModel.role = role.Name;



            if (user == null)
            {
                return NotFound();
            }

            return Ok(userModel);
        }


    }

}
