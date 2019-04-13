using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    
    public class Mandate
    {
     
        [Key, Column(Order = 0)]
        public int projectId { get; set; }
        [Key, Column(Order = 1)]
        public int userId { get; set; }
        //[Key, Column(Order = 3)]
       // public int eventId { get; set; }
        public  DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int duration { get; set; }

        public int cost { get; set; }

        //   public virtual Events evvent{ get;set; }

        public virtual Resource resource { get; set; }
 
        public virtual Project project { get; set; }
    }
}
