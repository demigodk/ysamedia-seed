using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class DependantCategory
    {
        public DependantCategory()
        {
            Dependant = new HashSet<Dependant>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryCount { get; set; }

        public ICollection<Dependant> Dependant { get; set; }
    }
}
