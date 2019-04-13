using Domain.Entities;
using ProjetPiMap.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetPiMap.Controllers
{
    public class ProjectController : Controller
    {
        IProjectService serviceP = new ServiceProject();
        IServiceClient serviceC = new ServiceCustomer();

        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectViewModel collection)
        {
            Project pro = new Project();



            pro.state = collection.state;
            pro.numberResource = collection.numberResource;
            pro.description = collection.description;
            pro.price = collection.price;
            pro.duration = collection.duration;
            pro.startDay = collection.startDay;
            pro.endDay = collection.endDay;

            // pro.userId = 5;



            serviceP.Add(pro);
            serviceP.Commit();
            return View();
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
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

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
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
