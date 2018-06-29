using System.ComponentModel.DataAnnotations;

namespace ysamedia.Models.UserProfileViewModels
{
    public class UserScreeningQuestionViewModel
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]        
        public string Question1 { get; set; }

        [Required]
        public string Question2 { get; set; }

        [Required]
        public string Question3 { get; set; }

        [Required]
        public string Question4 { get; set; }
    }
}
