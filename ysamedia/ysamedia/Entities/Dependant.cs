using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Dependant
    {
        public int DependantId { get; set; }
        public int? ChurchMemberId { get; set; }
        public int? NumDependant { get; set; }
        public int? DependantCategoryId { get; set; }

        public ChurchMember ChurchMember { get; set; }
        public DependantCategory DependantCategory { get; set; }
    }
}
