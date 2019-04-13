using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using ProjetPiMap.Models;
using Service;


namespace ProjetPiMap.Controllers
{
    public class ResourcesController : Controller
    {
        IServiceResources serviceResources = new ServiceResources();

        // GET: Resources
        public ActionResult Index()
        {
            List<UserModel> list = new List<UserModel>();
            foreach (var item in serviceResources.GetAll())
            {

                UserModel fv = new UserModel();
                fv.userId = item.Id;
                fv.firstname = item.firstname;
                fv.lastname = item.lastname;
                fv.Email = item.Email;
                fv.address = item.address;
                fv.phoneNumber = item.PhoneNumber;


                //return (item.Roles.Any("Resource"));

                list.Add(fv);

            }
            /**using (MailMessage mailMessage =
        new MailMessage(new MailAddress("jasser.hadhri11@gmail.com"),
    new MailAddress("jasser.hadhri11@gmail.com")))
            {
                mailMessage.Body = "It works";
                mailMessage.Subject = "Mail";
                try
                {
                    SmtpClient SmtpServer = new SmtpClient();
                    SmtpServer.Credentials =
                        new System.Net.NetworkCredential("monguide07@gmail.com", "so what00112233");
                    SmtpServer.Port = 587;
                    SmtpServer.Host = "smtp.gmail.com";
                    SmtpServer.EnableSsl = true;
                    var mail = new MailMessage();
                    mail.From = new MailAddress("monguide07@gmail.com");
                    Byte i;

                    mail.To.Add("jasser.hadhri11@gmail.com");
                    mail.Subject = "Mail";
                    mail.Body = "it works";
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions =
                        DeliveryNotificationOptions.OnFailure;
                    //   mail.ReplyTo = new MailAddress(toemail);
                    mail.ReplyToList.Add("jasser.hadhri11@gmail.com");
                    SmtpServer.Send(mail);
                }
                catch (Exception ex)
                {
                    string exp = ex.ToString();
                }
                
            }**/
            return View(list);
        }

        // GET: Resources/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resources/Create
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

        // GET: Resources/Edit/5
        public ActionResult Edit(int id)
        {
            ResourcesViewModel vm = new ResourcesViewModel();
            Resource r = serviceResources.GetById(id);
            vm.Id = r.Id;
            vm.address = r.address;
            vm.availibilities = r.availibilities;
            vm.businessSector = r.businessSector;
            vm.CV = r.CV;
            return View(vm);
            
        }

        // POST: Resources/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection vm)
        {
            try
            {
                // TODO: Add update logic here
                Resource r = new Resource();

                r = serviceResources.GetById(id);

                r.address = vm["address"];
                
                serviceResources.Update(r);
                serviceResources.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int id)
        {
            ResourcesViewModel user = new ResourcesViewModel();
            Resource resource = new Resource();
            resource = serviceResources.GetById(id);
            user.Id = resource.Id;
            user.firstname = resource.firstname;
            user.lastname = resource.lastname;
            user.Email = resource.Email;
            return View(user);
            
        }

        // POST: Resources/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                var user = serviceResources.GetById(id);
                serviceResources.Delete(user);
                serviceResources.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Approuver(int id)
        {
            Resource resource = serviceResources.GetById(id);
            resource.TwoFactorEnabled = true;

            serviceResources.Update(resource);
            serviceResources.Commit();
            return RedirectToAction("Index");
        }
    }
}
