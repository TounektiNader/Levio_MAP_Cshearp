using Domain.Entities;
using Microsoft.AspNet.Identity;
using ProjetPiMap.Models;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetPiMap.Controllers
{
    public class AttachmentController : Controller
    {
        IServiceAttachment serviceAttachment = new ServiceAttachment();
        IServiceFolder serviceFolder = new ServiceFolder();
        IServiceJobRequest serviceJobRequest = new ServiceJobRequest();

  






        // GET: Attachment
        public ActionResult Index()
        {

            JobRequest jobrequest = serviceJobRequest.GetAll().Where(a => a.userId == User.Identity.GetUserId<int>()).SingleOrDefault();
            Folder folder = serviceFolder.GetAll().Where(a => a.jobRequestId == jobrequest.jobRequestId).SingleOrDefault();
              
            List<AttachmentModel> list = new List<AttachmentModel>();
            foreach (var item in serviceAttachment.GetAll().Where(a=>a.folderId==folder.folderId))
            {
                AttachmentModel attachmentModel = new AttachmentModel();
                attachmentModel.typeAttachment = item.typeAttachment;
                attachmentModel.lienAttachment = item.lienAttachment;
                attachmentModel.attachmentId = item.attachmentId;
                attachmentModel.approved = item.proved; 
                list.Add(attachmentModel);
            }
            


            return View(list);
           
        }



     



        public ActionResult listAttachmentByJob(int idJobRequest,int idUser)
        {

               JobRequest jobrequest = serviceJobRequest.GetAll().Where(a => a.jobRequestId == idJobRequest&& a.userId==idUser).SingleOrDefault();

            Folder folder = serviceFolder.GetAll().Where(a => a.jobRequestId == idJobRequest).SingleOrDefault();

            List<AttachmentModel> list = new List<AttachmentModel>();
            foreach (var item in serviceAttachment.GetAll().Where(a => a.folderId == folder.folderId))
            {
                AttachmentModel attachmentModel = new AttachmentModel();
                attachmentModel.typeAttachment = item.typeAttachment;
                attachmentModel.lienAttachment = item.lienAttachment;
                attachmentModel.attachmentId = item.attachmentId;
                attachmentModel.approved = item.proved;
                list.Add(attachmentModel);
            }

            return View(list);

        }

        public ActionResult ApprouverAttachment(int idAttachment)
        {

            Attachment attachment = serviceAttachment.GetById(idAttachment);

            attachment.proved = "Proved";
            serviceAttachment.Update(attachment);
            serviceAttachment.Commit();

            return RedirectToAction("listOffers", "JobRequest");

        }



        // GET: Attachment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Attachment/Create
        public ActionResult Create()
        {
        
            return View();
        }

        // POST: Attachment/Create
        [HttpPost]
        public ActionResult Create(String Name, HttpPostedFileBase file)
        {
            Attachment attachment = new Attachment();
            //A completer le folder id 





            List<JobRequest> jobrequests = serviceJobRequest.GetAll().Where(a => a.userId == User.Identity.GetUserId<int>()).ToList();
            List<Folder> listsFolder = new List<Folder>();
            foreach(var item in jobrequests)
            {

                foreach(var item2 in serviceFolder.GetAll().Where(a => a.jobRequestId == item.jobRequestId))
                { 
                Folder folder = new Folder();
                    folder.folderId = item2.folderId;
                    listsFolder.Add(folder);
                        }
            }







           
            if (file == null)
            {
            //    ModelState.AddModelError(attachmentModel.lienAttachment, "Please Select CV");
                return View();

            }
            if (!(file.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document”" || file.ContentType == "application/pdf"))
            {
               // ModelState.AddModelError(attachmentModel.lienAttachment, "Only .docs and .pdf file  allowed");
                return View();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    file.SaveAs(Path.Combine(Server.MapPath("~/UploadAttachment"), fileName));
                    foreach(var item in listsFolder) { 
                    attachment.folderId = item.folderId;
                    attachment.typeAttachment = Name;
                    attachment.lienAttachment = fileName;
                    attachment.proved = "Pending";
                    serviceAttachment.Add(attachment);
                    serviceAttachment.Commit();
                    }
              

                    ViewBag.Message = "Successufuly Done";
                }
                catch  { ViewBag.Message = "Error Please try  again !!"; }


            }





            return RedirectToAction("Index", "Attachment");

        }

        // GET: Attachment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Attachment/Edit/5
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

        // GET: Attachment/Delete/5
        public ActionResult Delete(int id)
        {
            Attachment attachment = serviceAttachment.GetById(id);
            serviceAttachment.Delete(attachment);
            serviceAttachment.Commit();
            return RedirectToAction("Index", "Attachment");
        }

        // POST: Attachment/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, AttachmentModel attachmentModel)
        //{
        //    Attachment attachment = new Attachment();
        //    attachment = serviceAttachment.GetById(id);
        //    try
        //    {
        //        attachmentModel.attachmentId = attachment.attachmentId;
        //        attachmentModel.typeAttachment = attachment.typeAttachment;
          
        //        serviceAttachment.Delete(attachment);
        //        serviceAttachment.Commit();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        public ActionResult listAttachments()
        {
            JobRequest jobrequest = serviceJobRequest.GetAll().Where(a => a.userId == User.Identity.GetUserId<int>()).SingleOrDefault();
            Folder folder = serviceFolder.GetAll().Where(a => a.jobRequestId == jobrequest.jobRequestId).SingleOrDefault();

            List<AttachmentModel> list = new List<AttachmentModel>();
            foreach (var item in serviceAttachment.GetAll().Where(a => a.folderId == folder.folderId))
            {
                AttachmentModel attachmentModel = new AttachmentModel();
                attachmentModel.typeAttachment = item.typeAttachment;
                attachmentModel.lienAttachment = item.lienAttachment;
                attachmentModel.attachmentId = item.attachmentId;
                attachmentModel.approved = item.proved;

                list.Add(attachmentModel);
            }
            return View(list);

            
        }


        public ActionResult ShowFile(string attachment)
        {
        //    var path = @"C:\Documents and Settings\nickla\Desktop";
            var path = @"C:\Users\Nader\Documents\GitHub\Map2018PI\Map2018IConsult\ProjetPiMap\UploadAttachment";
            var file = Path.Combine(path, attachment);
            file = Path.GetFullPath(file);
            if (!file.StartsWith(path))
            {
                // someone tried to be smart and sent 
                // ?filename=..\..\creditcard.pdf as parameter
                throw new HttpException(403, "Forbidden");
            }
            return File(file, "application/pdf");
        }
    }
}
