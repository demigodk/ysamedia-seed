using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ysamedia.Models.TimeLogViewModels
{
    public class ShowLogViewModel
    {
        [Required(ErrorMessage = "Please select a date for your entry")]
        [Display(Name = "Date")]
        public string date { get; set; }

        public int logId { get; set; }

        public int timeInId { get; set; }

        public string Userid { get; set; }

        public static List<ShowLogViewModel> Logs { get; set; }
    }
}
