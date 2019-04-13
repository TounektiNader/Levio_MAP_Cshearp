using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using ProjetPiMap.Models;
using Service;

namespace ProjetPiMap.Controllers
{
    public class SkillsController : Controller
    {
        IServiceSkill skill = new ServiceSkill();
        // GET: Skills
        public ActionResult Index()
        {
            List<SkillsViewModel> list = new List<SkillsViewModel>();
            foreach (var item in skill.GetAll())
            {
                SkillsViewModel skills = new SkillsViewModel();
                skills.experience = item.experience;
                skills.speciality = item.speciality;
                skills.levelStudy = item.levelStudy;
                skills.skillId = item.skillId;
                list.Add(skills);
            }
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SkillsViewModel model)
        {
            Skills skills = new Skills();
            skills.experience = model.experience;
            skills.levelStudy = model.levelStudy;
            skills.speciality = model.speciality;
            skill.Add(skills);
            skill.Commit();

            return RedirectToAction("Resource");
        }
        public ActionResult Delete(int id)
        {
            SkillsViewModel skills = new SkillsViewModel();
            Skills sk = new Skills();
            sk = skill.GetById(id);
            skills.skillId = sk.skillId;
            skills.experience = sk.experience;
            skills.levelStudy = sk.levelStudy;
            skills.speciality = sk.speciality;
            return View(skills);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var user = skill.GetById(id);
                skill.Delete(user);
                skill.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }
    }
}