using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using ysamedia.Models.AccountViewModels;

namespace ysamedia.Classes.Validation
{
    public class DateOfBirthAttribute : ValidationAttribute/*, IClientModelValidator*/
    {
        private int _month;       
        private int _day;

        public DateOfBirthAttribute(int month, int day)
        {
            _month = month;           
            _day = day;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            RegisterViewModel viewModel = (RegisterViewModel)validationContext.ObjectInstance;

            if (viewModel.Month == 2 && viewModel.Day > 28)
            {
                return new ValidationResult(GetFebErrorMessage());
            }

            return ValidationResult.Success;
        }

        private string GetFebErrorMessage()
        {
            return $"February does not have {_day} as a day.";
        }
    }
}
