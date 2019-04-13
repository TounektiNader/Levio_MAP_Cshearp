using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Message
    {
        [Key, Column(Order = 0)]
        public int messageId { get; set; }
        public int receiverId { get; set; }
        
        public String description { get; set; }
    
        public int userId { get; set; }
        
        
        public virtual Customer customer { get; set; }
     
        public virtual Resource resource { get; set; }

    }
}
