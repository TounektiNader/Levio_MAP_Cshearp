using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace ProjetPiMap.Models
{
    public class ResourcesViewModel : User
    {
        public String CV { get; set; }
        public String grade { get; set; }
        public String type { get; set; }
        public String score { get; set; }
        public String businessSector { get; set; }

        //     public int skillId { get; set; }

        //[ForeignKey("skillId")]
        public virtual ICollection<Skills> skills { get; set; }

        public virtual ICollection<Project> projects { get; set; }


        public virtual ICollection<Availibility> availibilities { get; set; }

        public ICollection<JobRequest> jobRequests { get; set; }

        public virtual ICollection<Message> messages { get; set; }
        [ForeignKey("userId")]
        public virtual ICollection<Mandate> mandates { get; set; }


    }
}