using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public  class Answers
    {
        [Key, Column(Order = 0)]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAnswer { get; set; }
        public String answer { get; set; }


        public int idTest { get; set; }
        public int idUser { get; set; }
        public virtual Test Test { get; set; }
        public virtual Resource resource { get; set; }

    }
}
