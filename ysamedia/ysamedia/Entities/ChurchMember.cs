using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ysamedia.Entities
{
    public partial class ChurchMember
    {
        [Key]
        public int ChurchMemberId { get; set; }

        [Display(Name = "Name(s)")]
        [Required(ErrorMessage = "Please Enter A First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please Enter A Surname")]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Month")]
        public int? Month { get; set; }

        [Display(Name = "Year")]
        public int? Year { get; set; }

        [Display(Name = "Day")]
        public int? Day { get; set; }

        [Display(Name = "Age Group")]
        [Required(ErrorMessage = "Please Select An Age Group")]
        public int? AgeGroupId { get; set; }

        [Display(Name = "Marital Status")]
        [Required(ErrorMessage = "Please Select A Marital Status")]
        public int? RelationshipId { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Enter A Gender")]
        public int GenderId { get; set; }

        [Display(Name = "Occupation")]
        [Required(ErrorMessage = "Please Select An Occupation")]
        public int OccupationId { get; set; }

        /******* Number Of Dependants in Different categories ***/
        [Display(Name = "Pre-School")]
        public int? NumDepInPreSchool { get; set; }

        [Display(Name = "Primary")]
        public int? NumDepInPrimary { get; set; }

        [Display(Name = "High-School")]
        public int? NumDepInHighSchool { get; set; }

        [Display(Name = "Tertiary")]
        public int? NumDepInTertiary { get; set; }

        /************* Contact Details ***************************/
        [Display(Name = "Cell Number")]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [Display(Name = "Home Number")]
        [DataType(DataType.PhoneNumber)]
        public string HomePhone { get; set; }

        [Display(Name = "Work Number")]
        [DataType(DataType.PhoneNumber)]
        public string WorkPhone { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter A Valid Email")]
        public string Email { get; set; }

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

        [Display(Name = "Q1. In which denomination or church do you belong to?")]
        public string AnswerToQ1 { get; set; }

        [Display(Name = "Q2. What brought you here to Yahweh Shamma Assembly?")]
        public string AnswerToQ2 { get; set; }

        [Display(Name = "Q3. Have you been baptized?")]
        public string AnswerToQ3 { get; set; }

        [Display(Name = "Q4. (If you answered YES to Q3) When were you baptized?")]
        public string AnswerToQ4 { get; set; }

        [Display(Name = "Q5. Would you please give some comment about the service that you have just attended?")]
        public string AnswerToQ5 { get; set; }

        [Display(Name = "Q6. Would you like to follow some teachings and become a member at our community?")]
        public string AnswerToQ6 { get; set; }

        [Display(Name = "Date Recorded")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateRegistered { get; set; }

        /**************** Connected Tables **********************/
        [Display(Name = "Age group")]
        public AgeGroup AgeGroup { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Occupation")]
        public Occupation Occupation { get; set; }

        [Display(Name = "Marital Status")]
        public RelationshipStatus Relationship { get; set; }
    }
}
