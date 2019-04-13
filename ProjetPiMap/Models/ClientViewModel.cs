using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class ClientViewModel
    {
        public String type { get; set; }
        public String description { get; set; }
        public String category { get; set; }
        public String speciality { get; set; }
       
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String address { get; set; }
        public int userId { get; set; }
        public String logo { get; set; }


    }
}