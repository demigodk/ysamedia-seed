using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblTimeIn
    {
        public int TimeId { get; set; }
        public string Category { get; set; }
        public int LogId { get; set; }
        public int? TimeCount { get; set; }

        public TblLog Log { get; set; }
    }
}
