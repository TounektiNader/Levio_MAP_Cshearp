using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class OfferJobs
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int offerId { get; set; }
        public int userId { get; set; }
        public String  JobType { get; set; }
        public String JobExperience { get; set; }
        [DataType(DataType.MultilineText)]
        public String JobDescription { get; set; }
        public String JobRequirements { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime LastDay { get; set; }
        public String ExpectedSalary { get; set; }
        public virtual Admin admin { get; set; }
        public virtual ICollection<JobRequest> jobRequest { get; set; }

    }
}
