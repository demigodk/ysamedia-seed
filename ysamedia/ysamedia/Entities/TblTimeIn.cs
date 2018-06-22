using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblTimeIn
    {
        public TblTimeIn()
        {
            TblLog = new HashSet<TblLog>();
        }

        public int TimeId { get; set; }
        public string Category { get; set; }
        public int? TimeCount { get; set; }

        public ICollection<TblLog> TblLog { get; set; }
    }
}
