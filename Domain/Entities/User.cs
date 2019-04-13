using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  abstract class User : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
 
         [Required]
        public String firstname { get; set; }
        [Required]

        public String lastname { get; set; }

      //  [Display(Name = "psd")]
        // [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Required]

        [DataType(DataType.Password)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        public String motDePasse { get; set; }
        //[NotMapped]
        //[Compare("psd", ErrorMessage = "The password and confirmation password do not match.")]
        //[Required]

//        public String confirmPasse { get; set; }

  //      [Required(ErrorMessage = "Vous devez charger image")]
        [DataType(DataType.ImageUrl)]
        

        public String image { get; set; }

    

        [DataType(DataType.MultilineText)]
        public String address { get; set; }
        //  [Required]
        //    [DataType(DataType.PhoneNumber)]
        //    public int phoneNumber { get; set; }
        //public string role { get; set; }

        public virtual ICollection<Claim> claimss { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;

        }
        }
}



public class CustomUserLogin : IdentityUserLogin<int>
{
    public int Id { get; set; }

}
public class CustomUserRole : IdentityUserRole<int>
{
    public int Id { get; set; }
}
public class CustomUserClaim : IdentityUserClaim<int>
{

}
public class CustomRole : IdentityRole<int, CustomUserRole>
{
    public CustomRole() { }
    public CustomRole(string name) { Name = name; }
}




