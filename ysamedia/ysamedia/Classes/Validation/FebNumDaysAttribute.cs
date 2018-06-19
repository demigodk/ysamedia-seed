using System.ComponentModel.DataAnnotations;
using ysamedia.Models.AccountViewModels;

namespace ysamedia.Classes.Validation
{
    public class FebNumDaysAttribute : ValidationAttribute
    {
        private int _month;
        private int _day;
        RegisterViewModel viewModel;

        public FebNumDaysAttribute(int month, int day)
        {
            _month = month;
            _day = day;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            viewModel = (RegisterViewModel)validationContext.ObjectInstance;

            if (viewModel.Month == 2 && viewModel.Day > 28)
            {
                return new ValidationResult(GetErrorMessage());               
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"There is no {viewModel.Day} in February";
        }
    }
}

