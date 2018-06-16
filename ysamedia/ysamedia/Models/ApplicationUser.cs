using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ysamedia.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int Approved { get; set; }
    }
}
