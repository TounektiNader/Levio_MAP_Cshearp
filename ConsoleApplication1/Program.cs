using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            IServiceSkill servskill = new ServiceSkill();
            IServiceResources servresource = new ServiceResources();
            IProjectService servproj = new ServiceProject();
            IServiceProfile servprofil = new ServiceProfil();
            IServiceMandate servman = new ServiceMandate();
            List<Profil> lsprofil = new List<Profil>();
            List<Resource> lsresource = new List<Resource>();
            List<Skills> lsskills = new List<Skills>();
            Project p = servproj.Get(a => a.projectId == 1);
            IServiceUser servuser = new ServiceUser();

            lsprofil = servprofil.GetAll().Where(e => e.projectId == p.projectId).ToList();
            lsresource = servresource.GetAll().ToList();
            lsskills = servskill.GetAll().ToList();
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



                message.To.Add("anisbouda25@gmail.com");
                message.From = new MailAddress("anisalboudali@gmail.com");
                message.Subject = "Alerte Fin Mandat";
                message.Body = "Bonjour, Plus que 40 jours avant la fin de ce mandat!==>"+item.project.description;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("anisalboudali@gmail.com", "somethinglikethis");
                client.Send(message);

            }
        }
    }
}
