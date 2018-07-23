using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ysamedia.Entities
{
    public partial class ChurchMember
    {
        public ChurchMember()
        {
            Answer = new HashSet<Answer>();
            ChurchMemberOccupationBridge = new HashSet<ChurchMemberOccupationBridge>();
            Dependant = new HashSet<Dependant>();
        }

        [Key]
        public int ChurchMemberId { get; set; }

        [Display(Name = "Name(s)")]
        [Required(ErrorMessage = "Please Enter A First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please Enter A Surname")]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Cell Phone Number")]
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

        [Display(Name = "Date Recorded")]
        public DateTime? DateRegistered { get; set; }

        [Display(Name = "Age Group")]
        [Required(ErrorMessage = "Please Select An Age Group")]
        public int? AgeGroupId { get; set; }

        [Display(Name = "Marital Status")]
        [Required(ErrorMessage = "Please Select A Marital Status")]
        public int? RelationshipId { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Enter A Gender")]
        public int GenderId { get; set; }

        [Display(Name = "Street Address")]
        public string Street { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Province")]
        public string Province { get; set; }

        [MaxLength(4), MinLength(4)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Occupation")]
        [Required(ErrorMessage = "Please Select An Occupation")]
        public int OccupationId { get; set; }

        [Display(Name = "Pre-School")]
        public int? NumDepInPreSchool { get; set; }

        [Display(Name = "Primary")]
        public int? NumDepInPrimary { get; set; }

        [Display(Name = "High-School")]
        public int? NumDepInHighSchool { get; set; }

        [Display(Name = "Tertiary")]
        public int? NumDepInTertiary { get; set; }

        [Display(Name = "Q1. In which denomination or church do you belong to?")]
        public string AnswerToQ1 { get; set; }

        [Display(Name = "Q2. What brought you here to Yahweh Shamma Assembly?")]
        public string AnswerToQ2 { get; set; }

        [Display(Name = "Q3. Have you been baptized?")]
        public string AnswerToQ3 { get; set; }

        [Display(Name = "Q4. (If you answered \"Yes\" to Q3) When were you baptized?")]
        public string AnswerToQ4 { get; set; }

        [Display(Name = "Q5. Would you please give some comment about the service that you have just attended?")]
        public string AnswerToQ5 { get; set; }

        [Display(Name = "Q6. Would you like to follow some teachings and become a member at our community?")]
        public string AnswerToQ6 { get; set; }

        public AgeGroup AgeGroup { get; set; }
        public Gender Gender { get; set; }
        public Occupation Occupation { get; set; }
        public RelationshipStatus Relationship { get; set; }
        public ICollection<Answer> Answer { get; set; }
        public ICollection<ChurchMemberOccupationBridge> ChurchMemberOccupationBridge { get; set; }
        public ICollection<Dependant> Dependant { get; set; }
    }
}
