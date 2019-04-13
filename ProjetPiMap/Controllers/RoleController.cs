using Data;
using Microsoft.AspNet.Identity.Owin;
using ProjetPiMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjetPiMap.Controllers
{
    public class RoleController : Controller
    {
     
        private ApplicationRoleManager _roleManager;

        public RoleController()
        {
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }



        // GET: Role
        public ActionResult Index()
        {
            List<RoleViewModel> list = new List<RoleViewModel>();
            foreach (var role in RoleManager.Roles)
                list.Add(new RoleViewModel(role));
                return View(list);
        }

        // GET: Role/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var role = await RoleManager.FindByIdAsync(id);
             
            return View(new RoleViewModel(role));
        }

        // GET: Role/Create
        public ActionResult Create()
        {
        //    var role = new CustomRole();
            return View();
        }

        // POST: Role/Create
       [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel  model)
        {
            var role = new CustomRole() { Name = model.Name };
            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
            
        }

        // GET: Role/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role)); 
        }

        // POST: Role/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(RoleViewModel model)
        {
            var role = new CustomRole() { Id = model.Id, Name = model.Name };
            await RoleManager.UpdateAsync(role);
            return RedirectToAction("Index");
            
        }

        // GET: Role/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var role = await RoleManager.FindByIdAsync(id);

            return View(new RoleViewModel(role));
        }

        // POST: Role/Delete/5
        [HttpPost]
        public async Task<ActionResult> ConfirmDelete(int id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("Index"); 

        }
    }
}
