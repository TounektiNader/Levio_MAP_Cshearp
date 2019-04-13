using Domain.Entities;
using Microsoft.AspNet.Identity;
using ProjetPiMap.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ProjetPiMap.Controllers
{
    public class ProjectServiceConsomController : ApiController
    {

        IProjectService Serviceproj = new ServiceProject();
        IServiceClient sclient = new ServiceCustomer();
        // GET: ProjectServiceConsom


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/EditProject")]
        public IHttpActionResult EditProject(int id)
        {
            Project proj = Serviceproj.GetById(id);
            Models.ProjectViewModel project = new Models.ProjectViewModel();
        project.description = proj.description;
            project.duration = proj.duration;
            project.endDay = proj.endDay;
            project.startDay = proj.startDay;
            project.numberResource = proj.numberResource;

            return Ok(project);
    }


        //[System.Web.Http.HttpPut]
        //[System.Web.Http.Route("api/Edit")]
        //public IHttpActionResult Edit(int id, ProjectViewModel collection)
        //{
        //    Project proj = Serviceproj.GetById(id);
        //    ProjectViewModel project = new ProjectViewModel();

        //    Project proj = serviceP.GetById(id);
        //    // proj.projectId = collection.projectId;
        //    proj.description = collection.description;
        //    proj.duration = collection.duration;
        //    proj.endDay = collection.endDay;
        //    proj.startDay = collection.startDay;
        //    proj.numberResource = collection.numberResource;

        //    serviceP.Update(proj);
        //    serviceP.Commit();


        //    return RedirectToAction("AfficheProjetClient");

        //}



        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Afficher/{id}")]
        public List<ProjectViewModel> Afficher(int id )
        {
            List<Models.ProjectViewModel> list1 = new List<Models.ProjectViewModel>();

            Models.ProjectViewModel pro = null;
          return  Serviceproj.GetAll().Where(s => s.isApprouve == true).Where(s=>s.userId==id).Select(s => new ProjectViewModel()
            {
                projectId = s.projectId,
                numberResource = s.numberResource,
                userId=s.userId,
              description = s.description,
             price = s.price,
              duration = s.duration,
            endDay = s.endDay,
            state=s.state,
            startDay = s.startDay,
            prixRetard = s.prixRetard * s.nbJrsProlongation,
            isApprouve=s.isApprouve,
            nbJrsProlongation=s.nbJrsProlongation
            
           




        }).ToList();

            
        }
      

    }
}