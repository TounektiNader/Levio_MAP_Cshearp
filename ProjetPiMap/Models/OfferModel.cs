using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class OfferModel
    {
        public int offerId { get; set; }
        public int userId { get; set; }
        public String JobType { get; set; }
        public String JobExperience { get; set; }
        public String JobDescription { get; set; }
        public String JobRequirements { get; set; }
        public String PostedOn { get; set; }
        public DateTime LastDay { get; set; }
        public String ExpectedSalary { get; set; }
    }
}