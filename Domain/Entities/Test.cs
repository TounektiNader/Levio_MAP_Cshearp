using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public  class Test
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int testId { get; set; }
        public string type { get; set; }
        public string question { get; set; }
        public string reponse { get; set; }
        public string choix1 { get; set; }

        public string choix2 { get; set; }
        public int userId { get; set; }
        public virtual Admin admin { get; set; }
        public virtual ICollection<Answers> answers { get; set; }

    }
}
