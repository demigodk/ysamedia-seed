using System.Collections.Generic;
using ysamedia.Entities;

namespace ysamedia.Models.UserProfileViewModels
{
    public class CombinedProfileViewModel
    {
        public User UserViewModel { get; set; }
        public Gender GenderViewModel { get; set; }
        public List<NextOfKin> NextOfKinViewModel { get; set; }        
        public List<Language> LanguageViewModel { get; set; }
        public List<ScreeningAnswer> screeningAnswerViewModel { get; set; }
        public Photo PhotoViewModel { get; set; }
    }
}
