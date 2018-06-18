using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ysamedia.Entities;

namespace ysamedia.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "The {0} Must Be At Least {2} And At Max {1} Characters Long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "The {0} Must Be At Least {2} And At Max {1} Characters Long.", MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} Must Be At Least {2} And At Max {1} Characters Long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The Password And Confirmation Password Do Not Match.")]
        public string ConfirmPassword { get; set; }
        
        public DateTime DateOfBirth { get; set; }

        public int Month { get; set; }

        public string Day { get; set; }
             
        public string Year { get; set; }

        public List<TblGender> GenderList { get; set; }
        public List<Month> MonthList { get; set; }
    }

    public class Month
    {
        public int MonthId { get; set; }

        public string Name { get; set; }
    }
}
