using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Language
    {
        public int LanguageId { get; set; }
        public string Language1 { get; set; }
        public string Proficiency { get; set; }
        public bool? PrimaryLanguage { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
