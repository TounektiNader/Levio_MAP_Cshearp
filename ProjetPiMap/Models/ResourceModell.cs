using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class ResourceModell
    {

        public int idUser { get; set; }
        public String firstname { get; set; }

        public String Email;
        public String lastname { get; set; }
        public String grade { get; set; }
        public String type { get; set; }
        public String score { get; set; }
        public String businessSector { get; set; }
    }
}