using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class JobRequest
    {

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int jobRequestId { get; set; }
        public String state { get; set; }
        public DateTime dateApply { get; set; }
        public String speciality { get; set; }

        public int userId { get; set; }
        public int offerId { get; set; }



        public virtual ICollection<Folder> folders { get; set; }

        public virtual Resource resource { get; set; }

        public virtual OfferJobs offerJobs { get; set; }
    }
}
