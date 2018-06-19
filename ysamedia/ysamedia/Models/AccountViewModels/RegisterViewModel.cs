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
        [DateOfBirth(2,28)]
        public int Month { get; set; }

        [Required(ErrorMessage = "Please select day")]
        [DateOfBirth(2, 28)]
        public int Day { get; set; }
             
        [Required(ErrorMessage = "Please select year")]
        public int Year { get; set; }

        public List<TblGender> GenderList { get; set; }

        //public List<Month> MonthList { get; set; }
        //public List<Day> DayList { get; set; }
        //public List<Year> YearList { get; set; }       
    }

    //public class Day
    //{
    //    public int DayId { get; set; }
    //    public int DayNum { get; set; }
    //}

    //public class Month
    //{
    //    public int MonthId { get; set; }
    //    public string Name { get; set; }
    //}

    //public class Year
    //{
    //    public int YearId { get; set; }
    //    public int YearNum { get; set; }
    //}
}
