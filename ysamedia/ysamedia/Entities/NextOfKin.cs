using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ysamedia.Entities
{
    public partial class NextOfKin
    {
        [Key]
        public int KinId { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Work Number")]
        [DataType(DataType.PhoneNumber)]
        public string WorkNumber { get; set; }

        [Display(Name = "Relationship (e.g. Aunt)")]
        public string RelationshipType { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public User User { get; set; }
    }
}
