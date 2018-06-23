using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblLog
    {
        public int LogId { get; set; }
        public DateTime Date { get; set; }
        public int? TimeInId { get; set; }

        public TblTimeIn TimeIn { get; set; }
    }
}
