using System.ComponentModel.DataAnnotations;
using ysamedia.Models.AccountViewModels;

namespace ysamedia.Classes.Validation
{
    public class NovNumDaysAttribute : ValidationAttribute
    {
        private int _month;
        private int _day;
        RegisterViewModel viewModel;

        public NovNumDaysAttribute(int month, int day)
        {
            _month = month;
            _day = day;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            viewModel = (RegisterViewModel)validationContext.ObjectInstance;

            if (viewModel.Month == 11 && viewModel.Day > 30)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"There is no {viewModel.Day} in November";
        }
    }
}
