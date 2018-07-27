using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TimeIn
    {
        public TimeIn()
        {
            Log = new HashSet<Log>();
        }

        public int TimeId { get; set; }
        public string Category { get; set; }
        public int? TimeCount { get; set; }

        public ICollection<Log> Log { get; set; }
    }
}
