using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ysamedia.Models.UserViewModels
{
    public class UserViewModel
    {
        [Key]
        public string UserId { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]       
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public string Discriminator { get; set; }
        public string DisplayName { get; set; }
        public DateTime? DateJoinedDept { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please Enter A Surname")]
        public string Surname { get; set; }

        [Display(Name = "Name(s)")]
        [Required(ErrorMessage = "Please Enter A First Name")]
        public string FirstName { get; set; }

        [Phone]
        [Display(Name = "Home Phone Number")]
        public string HomeNumber { get; set; }

        [Phone]
        [Display(Name = "Home Phone Number")]
        public string WorkNumber { get; set; }

        public string PhysicalAddress { get; set; }
        public int? GenderId { get; set; }
        public int Approved { get; set; }
        public bool? DriverLicence { get; set; }

        /************* Physical Address **************************/
        [Display(Name = "Street Address")]
        public string Street { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Province")]
        public string Province { get; set; }

        [MaxLength(4), MinLength(4)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
    }
}
