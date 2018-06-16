using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblRelationshipStatus
    {
        public TblRelationshipStatus()
        {
            TblUser = new HashSet<TblUser>();
        }

        public int RelationshipId { get; set; }
        public string RelationshipCategory { get; set; }
        public int CategoryCounter { get; set; }

        public ICollection<TblUser> TblUser { get; set; }
    }
}
