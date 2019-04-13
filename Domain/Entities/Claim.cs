using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Claim
    {

        [Key, Column(Order = 0)]
        public int recId { get; set; }
        public String type { get; set; }
        public String topic { get; set; }
        [DataType(DataType.ImageUrl)]

        public String picture { get; set; }

        public String response { get; set; }

        public int userId { get; set; }
        //[ForeignKey("userId")]
        public virtual User user { get; set; }

    }
}
