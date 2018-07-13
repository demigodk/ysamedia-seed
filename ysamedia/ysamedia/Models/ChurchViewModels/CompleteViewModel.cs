using System;
using System.ComponentModel.DataAnnotations;

namespace ysamedia.Models.ChurchViewModels
{
    public class CompleteViewModel
    {
        [Display(Name = "Name(s)")]
        [Required(ErrorMessage = "Please Enter A First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please Enter A Surname")]
        public string Surname { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Enter A Gender")]
        public string GenderId { get; set; }

        /************* Date Of Birth ***************************/
        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please Enter A Month")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Please Enter A Day")]
        public int Day { get; set; }

        [Display(Name = "Year")]
        [Required(ErrorMessage = "Please Select A Year")]
        public string Year { get; set; }

        [Display(Name = "Age Group")]
        [Required(ErrorMessage = "Please Select An Age Group")]
        public string AGroupId { get; set; }

        [Display(Name = "Marital Status")]
        [Required(ErrorMessage = "Please Select A Marital Status")]
        public string RelationshipId { get; set; }

        /******* Number Of Dependants in Different categories ***/
        [Display(Name = "Pre-School")]
        public string NumPreschool { get; set; }

        [Display(Name = "Primary")]
        public string NumPrimary { get; set; }

        [Display(Name = "High-School")]
        public string NumHigh { get; set; }

        [Display(Name = "Tertiary")]
        public string NumTertiary { get; set; }

        [Display(Name = "Occupation")]
        [Required(ErrorMessage = "Please Select An Occupation")]
        public string OccupationId { get; set; }

        /************* Contact Details ***************************/
        [Display(Name = "Cell Number")]
        [DataType(DataType.PhoneNumber)]
        public string CellNumber { get; set; }

        [Display(Name = "Home Number")]
        [DataType(DataType.PhoneNumber)]
        public string HomeNumber { get; set; }

        [Display(Name = "Work Number")]
        [DataType(DataType.PhoneNumber)]
        public string WorkNumber { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter A Valid Email")]
        public string EmailAddress { get; set; }

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

        /************** Additional Information ********************/
        [Display(Name = "Q1")]
        public string Question1 { get; set; }

        [Display(Name = "Q2")]
        public string Question2 { get; set; }

        [Display(Name = "Q3")]
        public string Question3 { get; set; }

        [Display(Name = "Q4")]
        public string Question4 { get; set; }

        [Display(Name = "Q5")]
        public string Question5 { get; set; }

        [Display(Name = "Q6")]
        public string Question6 { get; set; }

        [Display(Name = "Date Recorded")]
        public DateTime? DateRecorded { get; set; }
    }
}
