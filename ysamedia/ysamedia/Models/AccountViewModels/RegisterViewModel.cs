using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ysamedia.Classes.Validation;
using ysamedia.Entities;

namespace ysamedia.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "The {0} Must Be At Least {2} And At Max {1} Characters Long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "The {0} Must Be At Least {2} And At Max {1} Characters Long.", MinimumLength = 2)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select gender")]
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
        
        [Display(Name = "Date Of Birth")]               
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select month")]  
        [AprNumDays(2, 28), FebNumDays(4, 30), JuneNumDays(6, 30), SepNumDays(9, 30), NovNumDays(11, 30)]
        public int Month { get; set; }

        [Required(ErrorMessage = "Please select day")]
        [AprNumDays(2, 28), FebNumDays(4, 30), JuneNumDays(6, 30), SepNumDays(9, 30), NovNumDays(11, 30)]
        public int Day { get; set; }
             
        [Required(ErrorMessage = "Please select year")]
        public int Year { get; set; }

        //public List<TblGender> GenderList { get; set; }       
    }   
}
