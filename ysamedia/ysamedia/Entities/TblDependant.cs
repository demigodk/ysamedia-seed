using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblDependant
    {
        public TblDependant()
        {
            TblDependantCategory = new HashSet<TblDependantCategory>();
        }

        public int DependantId { get; set; }
        public int? ChurchMemberId { get; set; }
        public int? NumDependant { get; set; }

        public TblChurchMember ChurchMember { get; set; }
        public ICollection<TblDependantCategory> TblDependantCategory { get; set; }
    }
}
