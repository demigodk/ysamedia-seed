using System;
using System.ComponentModel.DataAnnotations;

namespace ysamedia.Models.ChurchViewModels
{
    public class ChurchMemberViewModel
    {
        [Display(Name = "Name")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        //[Display(Name = "Date Of Birth")]
        //public DateTime? DateOfBirth { get; set; }
      
        [Display(Name = "Age Group")]
        public int AgeGroupId { get; set; }

        [Display(Name = "Marital Status")]
        public int RelationshipId { get; set; }
    }
}
