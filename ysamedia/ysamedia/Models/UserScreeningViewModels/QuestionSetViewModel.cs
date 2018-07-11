using System.ComponentModel.DataAnnotations;

namespace ysamedia.Models.UserScreeningViewModels
{
    public class QuestionSetViewModel
    {
        [Required(ErrorMessage = "Please Answer Q1.")]
        public string Question1 { get; set; }

        [Required(ErrorMessage = "Please Answer Q2.")]
        public string Question2 { get; set; }

        [Required(ErrorMessage = "Please Answer Q3.")]
        public string Question3 { get; set; }

        [Required(ErrorMessage = "Please Answer Q4.")]
        public string Question4 { get; set; }
    }
}
