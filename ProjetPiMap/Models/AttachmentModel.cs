using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class AttachmentModel
    {
        public int attachmentId { get; set; }
        [Required]

        public string typeAttachment { get; set; }
        [Required(ErrorMessage = "Please select your curriculum")]
        public string lienAttachment { get; set; }
        [Required]
        public int folderId { get; set; }

        public string approved { get; set; }
       
    }
}