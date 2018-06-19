using System.ComponentModel.DataAnnotations;
using ysamedia.Models.AccountViewModels;

namespace ysamedia.Classes.Validation
{
    public class JuneNumDaysAttribute : ValidationAttribute
    {
        private int _month;
        private int _day;
        RegisterViewModel viewModel;

        public JuneNumDaysAttribute(int month, int day)
        {
            _month = month;
            _day = day;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            viewModel = (RegisterViewModel)validationContext.ObjectInstance;

            if (viewModel.Month == 6 && viewModel.Day > 30)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"There is no {viewModel.Day} in June";
        }
    }
}
