using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace ProjetPiMap.Models
{
    public class SkillsViewModel
    {
        public int skillId { get; set; }
        public String speciality { get; set; }
        public int experience { get; set; }
        public ICollection<String> listAttachementsSkills { get; set; }
        public String levelStudy { get; set; }
        public virtual ICollection<Resource> lstresource { get; set; }
    }
}