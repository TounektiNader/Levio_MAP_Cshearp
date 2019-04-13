using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Project
    {
        [Key, Column(Order = 0)]
        public int projectId { get; set; }
        public String state { get; set; }
        public int numberResource { get; set; }
        public String description { get; set; }
        public float price { get; set; }
        public int duration { get; set; }
        public DateTime startDay { get; set; }
        public DateTime endDay { get; set; }      
        public int userId { get; set; }
        public bool isApprouve { get; set; } = false;
        public double prixRetard { get; set; }
        public int nbJrsProlongation { get; set; }

       
        public virtual ICollection<Profil> profils { get; set; }
      
        public virtual ICollection<Resource> resources { get; set; }
        [ForeignKey("projectId")]
        public virtual ICollection<Mandate> mandates { get; set; }


        public virtual Customer customer { get; set;  }

    }
}
