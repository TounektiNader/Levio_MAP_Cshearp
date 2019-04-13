using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Availibility
    {
        [Key,Column(Order = 0)]
        public int availibilityId { get; set; }
        public DateTime startDay { get; set; }
        public DateTime endDay { get; set; }
        public String state { get; set; }
        public int userId { get; set; }
    //    [ForeignKey("userId")]
        public virtual Resource resource { get; set; }

    }
}
