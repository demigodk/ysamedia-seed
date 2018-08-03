using System.ComponentModel.DataAnnotations;
using ysamedia.Entities;

namespace ysamedia.Models.LanguageViewModels
{
    public class LanguageViewModel
    {
        [Key]
        public int LanguageId { get; set; }

        [Display(Name = "Language")]
        [Required(ErrorMessage = "The Language Field Is Required")]
        public string Language1 { get; set; }

        [Display(Name = "Language Proficiency")]
        public string Proficiency { get; set; }

        [Display(Name = "Primary Language")]
        public bool? PrimaryLanguage { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
