using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : User
    {
        public String type { get; set; }
        public String description { get; set; }
        public String category { get; set; }
        public String speciality { get; set; }
        public String logo { get; set; }
        public virtual ICollection<Project> projects { get; set; }
    
        public virtual ICollection<Message> messages { get; set; }
    }
}
