using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ysamedia.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int Approved { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string DisplayName { get; set; }
        public int GenderId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
