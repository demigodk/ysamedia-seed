using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblDependant
    {
        public int DependantId { get; set; }
        public int? ChurchMemberId { get; set; }
        public int? NumDependant { get; set; }
        public int? DependantCategoryId { get; set; }

        public TblChurchMember ChurchMember { get; set; }
        public TblDependantCategory DependantCategory { get; set; }
    }
}
