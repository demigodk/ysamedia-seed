using System.ComponentModel.DataAnnotations;

namespace ysamedia.Models.TimeLogViewModels
{
    public class TimeLogViewModel
    {
        [Required(ErrorMessage = "Please select a date for your entry")]
        [Display(Name = "Date")]
        public string date { get; set; }

        public int year { get; set; }

        public int month { get; set; }

        [Display(Name = "Reason")]
        public string reason { get; set; }

        [MaxLength(450)]
        public string UserId { get; set; }
    }
}
