using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class ProjectViewModel
    {
        public String state { get; set; }
        public int numberResource { get; set; }
        public String description { get; set; }
        public float price { get; set; }
        public int duration { get; set; }
        public DateTime startDay { get; set; }
        public DateTime endDay { get; set; }
        public int projectId { get; set; }
              
        public int userId { get; set; }
        public double prixRetard { get; set; }
        public bool isApprouve { get; set; } = false;
        public int nbJrsProlongation { get; set; }
    }
}