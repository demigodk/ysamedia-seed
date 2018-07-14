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

        public int ChurchMemberId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        [Display(Name = "Home Number")]
        public string HomePhone { get; set; }

        [Display(Name = "Work Number")]
        public string WorkPhone { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Recorded")]
        public DateTime? DateRegistered { get; set; }

        [Display(Name = "Age Group")]
        public int? AgeGroupId { get; set; }

        [Display(Name = "Marital Status")]
        public int? RelationshipId { get; set; }

        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        [Display(Name = "Street")]
        public string Street { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Province")]
        public string Province { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        public AgeGroup AgeGroup { get; set; }
        public Gender Gender { get; set; }
        public RelationshipStatus Relationship { get; set; }
        public ICollection<Answer> Answer { get; set; }
        public ICollection<ChurchMemberOccupationBridge> ChurchMemberOccupationBridge { get; set; }
        public ICollection<Dependant> Dependant { get; set; }
    }
}
