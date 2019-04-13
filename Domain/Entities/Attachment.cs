using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Attachment
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int attachmentId { get; set; }
        [Required]
        public string typeAttachment { get; set; }
        [Required]
        public string lienAttachment { get; set; }
        public string proved { get; set; }

        public int folderId { get; set; }
        public Folder folder { get; set; }

        

    }
}
