using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ysamedia.Models.TimeLogViewModels
{
    public class TimeLogViewModel
    {
        [Key]
        public int LogId { get; set; }

        [Required(ErrorMessage = "Please select a date for your entry")]
        [Display(Name = "Date")]        
        public string date { get; set; }
                
        [MaxLength(450)]
        public string UserId { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please select at least one user")]              
        public List<string> SelectedIDArray { get; set; }

        [Required]
        [Display(Name = "Time In")]
        public int TimeInID { get; set; }
    }
}
