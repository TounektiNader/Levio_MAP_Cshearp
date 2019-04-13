using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class UserApiModel
    {

        public int id { get; set; }
        public String firstname { get; set; }

        public String lastname { get; set; }


        public String email { get; set; }

        public String motDePasse { get; set; }



        public String address { get; set; }

        public string phoneNumber { get; set; }
        public String role { get; set; }
    }
}