using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblLog
    {
        public TblLog()
        {
            TblTimeIn = new HashSet<TblTimeIn>();
        }

        public int LogId { get; set; }
        public DateTime Date { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Reason { get; set; }
        public string UserId { get; set; }

        public TblUser User { get; set; }
        public ICollection<TblTimeIn> TblTimeIn { get; set; }
    }
}
