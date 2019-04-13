using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetPiMap.Controllers
{
    public class eventController : Controller
    {
        ServiceEvent se = new ServiceEvent();
        // GET: event
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEvents()
        {
            var events = se.GetAll();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //action to request in a mandate creation
        [HttpPost]
        public ActionResult Create(String subject, String description, DateTime start, DateTime end)
        {
            Events e = new Events();
            e.Subject = subject;
            e.Description = description;
            e.End = end;
            e.Start = start;
            se.Add(e);
            se.Commit();

            return RedirectToAction("Index");
        }
    }
}