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
    public class CustomerController : Controller
    {
        IServiceClient service = new ServiceCustomer();
        // GET: Customer
        public ActionResult Index()
        {

            List<ClientViewModel> list = new List<ClientViewModel>();
            foreach (var item in service.GetAll())
            {
                ClientViewModel client = new ClientViewModel();
                client.type = item.type;
                client.category = item.category;
                client.description = item.description;
                client.speciality = item.speciality;



                list.Add(client);
            }

           
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(ClientViewModel collection)
        {

            Customer cust = new Customer();

            cust.type = collection.type;
            cust.description = collection.description;
            cust.category = collection.category;
            cust.speciality = collection.speciality;


            service.Add(cust);

            service.Commit();
            return RedirectToAction("Index");
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
