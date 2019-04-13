using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class OfferViewModel
    {
        public int offerId { get; set; }
        public int userId { get; set; }
        public String JobType { get; set; }
        public String JobExperience { get; set; }
        public String JobDescription { get; set; }
        public String JobRequirements { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime LastDay { get; set; }
        public String ExpectedSalary { get; set; }
        public int var1 { get; set; }
      public int var2 { get; set; }
     public int var3 { get; set; }
        public int var4 { get; set; }
    }
}