using Data;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using ProjetPiMap.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ProjetPiMap.Controllers
{
    public class CrudClaimsController : Controller
    {
        private Context db = new Context();
        IclaimService serviceclaime = new ClaimsService();
        IServiceUser serviceuser = new ServiceUser();

        // GET: CrudClaims
        public ActionResult Index(HttpPostedFileBase file)
        {

            List<Claim> list = new List<Claim>();
            List<User> listUser = new List<User>();
            foreach (var item in serviceclaime.getByUserId(1))
            {
                User us = serviceuser.getUserById(item.userId);
                Claim cl = new Claim();

                ClaimViewModel PVM = new ClaimViewModel();

                cl.userId = item.userId;
                cl.type = item.type;

                cl.topic = item.topic;
                cl.picture = item.picture;
                //if (cl.response == null)
                //{
                //    cl.response = item.response="processing";
                //}
                cl.response = item.response;
                cl.user = us;

                list.Add(cl);
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Index(string recherche)
        {
            List<ClaimViewModel> List = new List<ClaimViewModel>();

            foreach (var item in serviceclaime.getByUserId(1))
            {
                ClaimViewModel PVM = new ClaimViewModel();


                PVM.userid = item.userId = 1;
                PVM.type = item.type;

                PVM.topic = item.topic;



                List.Add(PVM);
            }
            if (!String.IsNullOrEmpty(recherche))
            {
                List = List.Where(m => m.type.Contains(recherche)).ToList();
            }

            return View(List);


        }


        // GET: CrudClaims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = db.Claims.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // GET: CrudClaims/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.Users, "userId", "firstname");
            return View();
        }

        // POST: CrudClaims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClaimViewModel collection, HttpPostedFileBase file)
        {

            Claim claim = new Claim();
            if (ModelState.IsValid)
            {
                var fileName = "";
                if (file.ContentLength > 0)


                {
                    fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/Content/upload"), file.FileName);
                    file.SaveAs(path);
                    claim.picture = file.FileName;
                    claim.topic = collection.topic;
                    claim.type = collection.type;
                    // claim.recId = collection.recId;
                    claim.userId = User.Identity.GetUserId<int>();

                }




                serviceclaime.Add(claim);
                serviceclaime.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.Users, "userId", "firstname", claim.userId);
            return View(claim);
        }

        // GET: CrudClaims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = db.Claims.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.Users, "userId", "firstname", claim.userId);
            return View(claim);
        }

        // POST: CrudClaims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recId,type,topic,userId")] Claim claim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.Users, "userId", "firstname", claim.userId);
            return View(claim);
        }

        // GET: CrudClaims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = db.Claims.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // POST: CrudClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Claim claim = db.Claims.Find(id);
            db.Claims.Remove(claim);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void SendMail(int id)
        {

            ClaimViewModel pro = new ClaimViewModel();
            Claim proj = serviceclaime.GetById(id);


            pro.user = serviceuser.getUserById(proj.userId);


            MailMessage mailMessage = new MailMessage("bechirguerfali2@gmail.com", "didi.dohaa@gmail.com");
            mailMessage.Subject = "Claim approved";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = string.Format("<html><head></head><body><b>Dear Mister " + pro.user.firstname + "</b> <br>your claim was treated succesully</b></body></html>");

            SmtpClient smtpClient = new SmtpClient();
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "bechirguerfali2@gmail.com",
                Password = "10.06.1993Gb"
            };
            //smtpClient.UseDefaultCredentials = false;
            smtpClient.Send(mailMessage);


        }

    }
}