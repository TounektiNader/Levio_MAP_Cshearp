using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Folder
    {
        [Key, Column(Order = 0)]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int folderId { get; set; }
        public string state { get; set; }
        public  string typeTest  { get; set; }
        public float testResult { get; set; }
        public String letterEmmployment { get; set; }
        public int jobRequestId { get; set; }
        public int etape { get; set; }


        public virtual JobRequest jobRequest { get; set; }

        public virtual ICollection<Attachment> attachments { get; set; }
        
     
    }
}
