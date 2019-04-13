using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class rsViewModel
    { public int iduser { get; set; }
        public int projid { get; set; }
        public String firstname { get; set; }
        public String lastName { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public String address { get; set; }


    }
}