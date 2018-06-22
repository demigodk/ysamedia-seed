using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblLog
    {
        public int LogId { get; set; }
        public DateTime Date { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Reason { get; set; }
        public string UserId { get; set; }
        public int? TimeInId { get; set; }

        public TblTimeIn TimeIn { get; set; }
        public TblUser User { get; set; }
    }
}
