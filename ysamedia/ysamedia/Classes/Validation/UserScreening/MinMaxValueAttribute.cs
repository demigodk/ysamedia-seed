using System.ComponentModel.DataAnnotations;
using ysamedia.Models.UserScreeningViewModels;

namespace ysamedia.Classes.Validation.UserScreening
{
    public class MinMaxValueAttribute : ValidationAttribute
    {
        private readonly int _inValue;
        UserScreeningViewModel viewModel;

        public MinMaxValueAttribute(int inValue)
        {
            _inValue = inValue;
        }
        
        private string GetErrorMessage()
        {
            return $"Please enter a value from 1 to 5";
        }
    }
}
