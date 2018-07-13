using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblDependantCategory
    {
        public TblDependantCategory()
        {
            TblDependant = new HashSet<TblDependant>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryCount { get; set; }

        public ICollection<TblDependant> TblDependant { get; set; }
    }
}
