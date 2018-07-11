using System.ComponentModel.DataAnnotations;

namespace ysamedia.Models.UserScreeningViewModels
{
    public class RatingViewModel
    {        
        [Required(ErrorMessage = "Please Answer Q1.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion1 { get; set; }

        [Required(ErrorMessage = "Please Answer Q2.")]
        [Range(1,5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion2 { get; set; }

        [Required(ErrorMessage = "Please Answer Q3.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion3 { get; set; }

        [Required(ErrorMessage = "Please Answer Q4.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion4 { get; set; }

        [Required(ErrorMessage = "Please Answer Q5.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion5 { get; set; }

        [Required(ErrorMessage = "Please Answer Q6.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion6 { get; set; }

        [Required(ErrorMessage = "Please Answer Q7.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion7 { get; set; }

        [Required(ErrorMessage = "Please Answer Q8.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion8 { get; set; }

        [Required(ErrorMessage = "Please Answer Q9.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion9 { get; set; }

        [Required(ErrorMessage = "Please Answer Q10.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion10 { get; set; }

        [Required(ErrorMessage = "Please Answer Q11.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion11 { get; set; }

        [Required(ErrorMessage = "Please Answer Q12.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion12 { get; set; }

        [Required(ErrorMessage = "Please Answer Q13.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion13 { get; set; }

        [Required(ErrorMessage = "Please Answer Q14.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion14 { get; set; }

        [Required(ErrorMessage = "Please Answer Q15.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]
        public int RQuestion15 { get; set; }

        [Required(ErrorMessage = "Please Answer Q16.")]
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 To 5")]
        [DataAnnotationsExtensions.Integer(ErrorMessage = "Please Enter A Valid Number")]        
        public int RQuestion16 { get; set; }
    }
}
