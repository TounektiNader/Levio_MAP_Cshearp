using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Skills
    {
        [Key,Column(Order = 0)]
        public int skillId { get; set; }
        public String speciality { get; set; }
        public int experience { get; set; }
        public ICollection<String> listAttachementsSkills { get; set; }
        public String levelStudy { get; set; }

        
        public virtual ICollection<Resource> lstresource { get; set; }


    }
}
