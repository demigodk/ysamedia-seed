using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ysamedia.Models.UserScreeningViewModels
{
    public class UserScreeningViewModel
    {
        //[Key]
        //public int ScreenQId { get; set; }

        public string Question1 { get; set; }

        public string Question2 { get; set; }

        public string Question3 { get; set; }

        public string Question4 { get; set; }

        public List<int> PosAttribute { get; set; }

        public List<int> NegAttribute { get; set; }

        //[Range(1, 5)]
        //[Display(Name = "Question 1")]
        //public int RQuestion1 { get; set; }

        //public int RQuestion2 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion3 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion4 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion5 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion6 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion7 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion8 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion9 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion10 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion11 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion12 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion13 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion14 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion15 { get; set; }

        //[Range(1, 5)]
        //public int RQuestion16 { get; set; }

        //[Required]
        //public DateTime DateRecorded { get; set; }
    }
}
