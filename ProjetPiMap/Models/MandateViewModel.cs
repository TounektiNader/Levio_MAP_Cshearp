using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class MandateViewModel
    {   public int userid { get; set; }
        public int mandateid { get; set; }
        public int projectid { get; set; }
       
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Project project { get; set; }
        public Resource resource { get; set; }
    }
}