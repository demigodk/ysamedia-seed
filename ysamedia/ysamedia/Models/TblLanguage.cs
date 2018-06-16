using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblLanguage
    {
        public int LanguageId { get; set; }
        public string Language { get; set; }
        public string Proficiency { get; set; }
        public bool? PrimaryLanguage { get; set; }
        public string UserId { get; set; }

        public TblUser User { get; set; }
    }
}
