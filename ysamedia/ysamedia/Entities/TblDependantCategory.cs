using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblDependantCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? DependantId { get; set; }
        public int? CategoryCount { get; set; }

        public TblDependant Dependant { get; set; }
    }
}
