using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TimeOff : Availibility
    {
        public String reason { get; set; }
        public int numberDays { get; set; }
        public int numberDaysRemaining { get; set; }
    }
}
