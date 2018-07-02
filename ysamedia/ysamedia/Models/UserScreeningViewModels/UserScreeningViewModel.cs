using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ysamedia.Models.UserScreeningViewModels
{
    public class UserScreeningViewModel
    {        
        [Required(ErrorMessage = "Please provide an answer for Q1.")]
        public string Question1 { get; set; }

        [Required]
        public string Question2 { get; set; }

        [Required]
        public string Question3 { get; set; }

        [Required]
        public string Question4 { get; set; }

        public List<int> PosAttribute { get; set; }

        public List<int> NegAttribute { get; set; }

        [Required(ErrorMessage = "Please provide an answer for Q1.")]
        public int RQuestion1 { get; set; }

        [Required(ErrorMessage = "Please provide an answer for Q1.")]
        public int RQuestion2 { get; set; }

        [Required]
        public int RQuestion3 { get; set; }

        [Required]
        public int RQuestion4 { get; set; }

        [Required]
        public int RQuestion5 { get; set; }

        [Required]
        public int RQuestion6 { get; set; }

        [Required]
        public int RQuestion7 { get; set; }

        [Required]
        public int RQuestion8 { get; set; }

        [Required]
        public int RQuestion9 { get; set; }

        [Required]
        public int RQuestion10 { get; set; }

        [Required]
        public int RQuestion11 { get; set; }

        [Required]
        public int RQuestion12 { get; set; }

        [Required]
        public int RQuestion13 { get; set; }

        [Required]
        public int RQuestion14 { get; set; }

        [Required]
        public int RQuestion15 { get; set; }

        [Required]
        public int RQuestion16 { get; set; }       
    }
}
