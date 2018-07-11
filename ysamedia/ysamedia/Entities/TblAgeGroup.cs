using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblAgeGroup
    {
        public TblAgeGroup()
        {
            TblChurchMember = new HashSet<TblChurchMember>();
        }

        public int AGroupId { get; set; }
        public string AgeRange { get; set; }

        public ICollection<TblChurchMember> TblChurchMember { get; set; }
    }
}
