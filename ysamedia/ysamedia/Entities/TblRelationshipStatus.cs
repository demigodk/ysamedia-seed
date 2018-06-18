using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblRelationshipStatus
    {
        public TblRelationshipStatus()
        {
            TblChurchMember = new HashSet<TblChurchMember>();
        }

        public int RelationshipId { get; set; }
        public string RelationshipCategory { get; set; }
        public int CategoryCounter { get; set; }

        public ICollection<TblChurchMember> TblChurchMember { get; set; }
    }
}
