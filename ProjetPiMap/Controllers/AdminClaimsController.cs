using Data;
using Domain.Entities;
using ProjetPiMap.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ProjetPiMap.Controllers
{
    public class AdminClaimsController : Controller
    {
        IServiceClient serviceC = new ServiceCustomer();

        private Context db = new Context();
        IclaimService serviceclaime = new ClaimsService();
        IServiceUser serviceuser = new ServiceUser();
        // GET: AdminClaims
        public ActionResult Index()
        {
            List<Claim> list = new List<Claim>();
            List<User> listUser = new List<User>();
            foreach (var item in serviceclaime.getAll())
            {
             
                Claim cl = new Claim();
                ClaimViewModel CVM = new ClaimViewModel();
                cl.recId = item.recId;
                cl.topic = item.topic;
                cl.type = item.type;
                //cl.user.firstname = item.user.firstname;
                //cl.user.lastname = item.user.lastname;
                if (cl.response == null)
                {
                    cl.response = "Processing";
                }
                cl.response = item.response;

               // cl.user = us;
                list.Add(cl);
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult Index(string recherche)
        {
            List<Claim> List = new List<Claim>();

            foreach (var item in serviceclaime.getAll())
            {
                Claim PVM = new Claim();

                //bech narj3louha 
                User us = serviceuser.getUserById(item.userId);


                PVM.userId = item.userId;
                PVM.type = item.type;

                PVM.topic = item.topic;
                //PVM.user.firstname = item.user.firstname;
                //PVM.user.lastname = item.user.lastname;
                PVM.user = us;
                us.lastname = item.user.lastname;
                List.Add(PVM);
            }
            if (!String.IsNullOrEmpty(recherche))
            {
                List = List.Where(m => m.type.Contains(recherche)).ToList();
            }

            return View(List);


        }


        // GET: AdminClaims/Details/5
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

        // GET: AdminClaims/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.Users, "userId", "firstname");
            return View();
        }

        // POST: AdminClaims/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "recId,type,topic,userId ")] Claim claim)
        {
            if (ModelState.IsValid)
            {

                db.Claims.Add(claim);
                claim.userId = 3;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.Users, "userId", "firstname", claim.userId);
            return View(claim);
        }

        // GET: AdminClaims/Edit/5
        public ActionResult Edit(int id)
        {
            return View(serviceclaime.GetById(id));
        }

        // POST: AdminClaims/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Claim c)
        {
            try
            {
                Claim cc = serviceclaime.GetById(id);
                cc.response = c.response;
                cc.recId = c.recId;
                //cc.topic = c.topic;
                //cc.type = c.type;
                //cc.userId = c.userId;
                serviceclaime.Update(cc);
                serviceclaime.Commit();
                SendMail(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminClaims/Delete/5
        public ActionResult Delete(int id)
        {
            return View(serviceclaime.GetById(id));
        }

        // POST: AdminClaims/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Claim c)
        {

            SendMail(id);

            serviceclaime.DeleteClaim(id);

            return RedirectToAction("Index");

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