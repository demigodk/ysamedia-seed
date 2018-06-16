using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblDependant
    {
        public TblDependant()
        {
            TblDependantCategory = new HashSet<TblDependantCategory>();
        }

        public int DependantId { get; set; }
        public string UserId { get; set; }
        public int? NumDependant { get; set; }

        public TblUser User { get; set; }
        public ICollection<TblDependantCategory> TblDependantCategory { get; set; }
    }
}
