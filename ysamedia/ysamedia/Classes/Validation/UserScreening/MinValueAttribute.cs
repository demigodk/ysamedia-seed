using System.ComponentModel.DataAnnotations;
using ysamedia.Models.UserScreeningViewModels;

namespace ysamedia.Classes.Validation.UserScreening
{
    public class MinValueAttribute : ValidationAttribute
    {
        private readonly int _inValue;
        RatingViewModel viewModel;

        public MinValueAttribute(int inValue)
        {
            _inValue = inValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {           
            viewModel = (RatingViewModel)validationContext.ObjectInstance;

            if (viewModel.RQuestion1 < 1 || viewModel.RQuestion1 > 5)
            {
                return new ValidationResult(GetErrorMessage());
            }           

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"Please Enter A Value Between 1 to 5";
        }
    }
}
