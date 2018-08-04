using System.ComponentModel.DataAnnotations;
using ysamedia.Entities;

namespace ysamedia.Models.NextOfKinViewModels
{
    public class NextOfKinViewModel
    {
        [Key]
        public int KinId { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber1 { get; set; }

        [Display(Name = "Work Number")]
        [Phone]
        public string WorkNumber1 { get; set; }

        [Display(Name = "Email Address")]        
        [EmailAddress]
        public string Email1 { get; set; }

        [Display(Name = "Relationship (e.g. Aunt)")]
        public string RelationshipType { get; set; }

        public User User { get; set; }
    }
}
