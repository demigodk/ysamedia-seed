using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblScreeningScripture
    {
        public int ScriptureId { get; set; }
        public string Book { get; set; }
        public string Chapter { get; set; }
        public string StartVerse { get; set; }
        public string EndVerse { get; set; }
        public string Scripture { get; set; }
        public string UserId { get; set; }

        public TblUser User { get; set; }
    }
}
