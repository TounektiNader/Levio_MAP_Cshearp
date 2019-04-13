using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetPiMap.Models
{
     public class UserModel
    {

        public int  userId { get; set; }

        [Required]
        public String firstname { get; set; }
        [Required]

        public String lastname { get; set; }


        [EmailAddress]
        [Required]

        public String Email { get; set; }

        [Required]

        [DataType(DataType.Password)]
        //  [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        public String motDePasse { get; set; }
        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("motDePasse", ErrorMessage = "The password and confirmation password do not match.")]
        [Required]

        public String confirmPasse { get; set; }



        [DataType(DataType.MultilineText)]
        public String address { get; set; }
      
        public string phoneNumber { get; set; }
        public String  role { get; set; }
    }
}