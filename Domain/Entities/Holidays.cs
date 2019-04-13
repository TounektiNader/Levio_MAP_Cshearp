using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Holidays : Availibility
    {
        public String name { get; set; }
        public int nnumberDays { get; set; }
    }
}
