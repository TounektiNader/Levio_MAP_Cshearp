using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Profil
    {
        [Key, Column(Order = 0)]
        public int profilId { get; set; }
        public String speciality { get; set; }
        public int experience { get; set; }
        public String test { get; set; }
        
        public int projectId { get; set; }
        public ICollection<String> listSkills { get; set; }
        
        public virtual Project project { get; set; }

    }
}
