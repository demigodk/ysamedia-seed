using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Log
    {
        public int LogId { get; set; }
        public DateTime Date { get; set; }
        public int? TimeInId { get; set; }

        public TimeIn TimeIn { get; set; }
    }
}
