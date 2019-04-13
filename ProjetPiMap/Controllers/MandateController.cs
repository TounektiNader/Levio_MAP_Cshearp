using Domain.Entities;
using ProjetPiMap.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace ProjetPiMap.Controllers
{
    public class MandateController : Controller
    {
        
        IServiceEvent servevent = new ServiceEvent();
        IServiceSkill servskill = new ServiceSkill();
        IServiceResources servresource = new ServiceResources();
        IProjectService servproj = new ServiceProject();
        IServiceProfile servprofil = new ServiceProfil();    
        IServiceMandate servman = new ServiceMandate();
        List<Profil> lsprofil = new List<Profil>();
        List<Resource> lsresource = new List<Resource>();
        List<Skills> lsskills = new List<Skills>();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public MandateController()
        {
        }

        public MandateController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
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
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Mandate
        public ActionResult Index()
        {
            List<MandateViewModel> list = new List<MandateViewModel>();
            
            foreach (var item in servman.GetAll())
            {   
                MandateViewModel m = new MandateViewModel();
                Project p = servproj.GetById(item.projectId);
                Resource r = servresource.GetById(item.userId);

               
                m.startDate = item.startDate;
                m.endDate = item.endDate;
                m.userid = item.userId;
                m.projectid = p.projectId;
                m.project = p;
                m.resource = r;
                
                
                
             
                
                list.Add(m);
            }
            return View(list);
        }
        public async Task<ActionResult> Assign(int idproj, int idres, DateTime start, DateTime end)
        {
            int endday = end.Day;
            int startday = start.Day;
            User user = await UserManager.FindByIdAsync(idres);
            Project p = servproj.Get(a=>a.projectId==idproj);
            Mandate m = new Mandate();
            m.projectId = idproj;
            m.userId = idres;
            m.startDate = start;
            m.endDate = end;
            m.duration = endday - startday;
            m.cost = 3;
            servman.Add(m);
            servman.Commit();
            
            Events ev = new Events();
            ev.Start = start;
            ev.End = end;
            ev.Description = user.lastname;
            ev.Subject = p.description;
            servevent.Add(ev);
            servevent.Commit();
            mandateEndNotif(user.Email,start,end);
            return View("Index");
        }
        public ActionResult getresources(int idproj, int idres, DateTime start, DateTime end)
        {
            List<rsViewModel> list = new List<rsViewModel>();
            Project p = servproj.Get(a => a.projectId == idproj);
            lsprofil = servprofil.GetAll().Where(e => e.projectId == p.projectId).ToList();
            lsresource = servresource.GetAll().ToList();
            lsskills = servskill.GetAll().ToList();
            //Mandate mand = servman.Get(a=>a.s);
            foreach (var item in lsprofil)
            {
                foreach(var item1 in lsskills)
                {
                    foreach(var item2 in item1.lstresource)
                    {
                        rsViewModel mv = new rsViewModel();
                        mv.address = item2.address;
                        mv.lastName = item2.lastname;
                        mv.firstname = item2.firstname;
                        mv.iduser = item2.Id;
                        mv.projid = p.projectId;
                        mv.start = start;
                        mv.end = end;
                        list.Add(mv);
                        
                    }
                }

            }



            return View(list);
        }


        // GET: Mandate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mandate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mandate/Create
        [HttpPost]
        public async Task <ActionResult> Create(MandateCreateViewModel collection) 
        {
            Project p = servproj.Get(a => a.projectId == collection.projectId);
            lsprofil = servprofil.GetAll().Where(e => e.projectId == p.projectId).ToList();
            lsresource = servresource.GetAll().ToList();
            lsskills = servskill.GetAll().ToList();
           
            foreach (var item in lsprofil)
            {
                foreach(var item2 in lsskills)
                {
                    foreach(var item3 in item2.lstresource)
                    {
                        User user = await UserManager.FindByEmailAsync(item3.UserName);
                        if (item.speciality.Equals(item2.speciality))
                        {
                            Mandate m = new Mandate();
                            m.projectId = p.projectId;
                            
                           
                            m.userId = user.Id;  
                            m.startDate = collection.StartDate;
                            m.endDate = collection.EndDate;
                         


                            int endday = collection.EndDate.Day;
                            int startday = collection.StartDate.Day;
                            m.duration = endday - startday;
                            m.cost = 3;
                            servman.Add(m);
                            servman.Commit();

                            //Resource e = servresource.GetById(item3.Id);

                            Events ev = new Events();
                            ev.Start = collection.StartDate;
                            ev.End = collection.EndDate;
                            ev.Description = p.description;
                            ev.Subject = user.lastname;
                            servevent.Add(ev);
                            servevent.Commit();

                            mandateEndNotif(user.Email, m.startDate,m.endDate);


                        }
                      


                    }
                }
            }



            return View();
        }
        
        // GET: Mandate/Edit/5
        public ActionResult Edit(int idproj, int idres)
        {
            Mandate man = servman.GetAll().Where(a => a.projectId == idproj).Where(t => t.userId == idres).First();
            MandateViewModel mv = new MandateViewModel();
            mv.userid = man.userId;
            mv.projectid = man.projectId;
            mv.startDate = man.startDate;
            mv.endDate = man.endDate;
            mv.project = man.project;
            mv.resource = man.resource;

           
            return View(mv);
        }

        // POST: Mandate/Edit/5
        [HttpPost]
        public ActionResult Edit(int idproj,int idres, MandateViewModel collection)
        {
            Mandate m = servman.GetAll().Where(a => a.projectId == idproj).Where(t => t.userId == idres).First();
            Resource re = servresource.GetById(idres);
            Events eventt = servevent.GetAll().Where(a => a.Subject.Equals(re.lastname) && a.Start == m.startDate && a.End==m.endDate).First();
            servevent.Update(eventt);
            servevent.Commit();

            m.startDate = collection.startDate;
            m.endDate = collection.endDate;
            m.project = collection.project;
            m.resource = collection.resource;
          
            servman.Update(m);
            servman.Commit();

           

            return RedirectToAction("Index");
                    }

        // GET: Mandate/Delete/5
        public ActionResult Delete(int idproj, int idres)
        {
            Mandate m = servman.GetAll().Where(a => a.projectId == idproj).Where(t => t.userId == idres).First();
            MandateViewModel mv = new MandateViewModel();
            mv.project = m.project;
            mv.resource = m.resource;
            mv.startDate = m.startDate;
            mv.endDate = m.endDate;
            mv.userid = m.userId;
            mv.projectid = m.projectId;
            

            return View(mv);
        }

        // POST: Mandate/Delete/5
        [HttpPost]
        public ActionResult Delete(int idproj,int idres, MandateViewModel collection)
        {
            Mandate m = servman.GetAll().Where(t => t.projectId == idproj).Where(g => g.userId == idres).First();
            m.startDate = collection.startDate;
            m.endDate = collection.endDate;
            m.project = collection.project;
            m.resource = collection.resource;
            m.projectId = collection.projectid;
            m.userId = collection.userid;
            Events e = servevent.GetAll().Where(a => a.Start == m.startDate && a.End == m.endDate).First();
            servevent.Delete(e);
            servevent.Commit();
            servman.Delete(m);
            servman.Commit();
            

            return RedirectToAction("index");
        }
        
        
        public async Task<ActionResult> mandateEndNotif(String email, DateTime start, DateTime end)
        {
            DateTime today = DateTime.Now;
            foreach (var item in servman.GetAll())
            {
                System.DateTime dTime = new System.DateTime(today.Year, today.Month, today.Day);
                System.TimeSpan tSpan = new System.TimeSpan(3, 0, 0, 0);
                DateTime finprojet = dTime + tSpan;
                //if (item.endDate.Equals(finprojet))
                //{

                //send mail
                MailMessage message = new MailMessage();



                message.To.Add(email);
                message.From = new MailAddress("anisalboudali@gmail.com");
                message.Subject = "Alerte Fin Mandat";
                message.Body = "Vous Avez été assigné à un projet!==>" + item.project.description+"du "+start+"au "+end;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("anisalboudali@gmail.com", "somethinglikethis");
                client.Send(message);

            }
            return RedirectToAction("Index");
        }
    }
}
