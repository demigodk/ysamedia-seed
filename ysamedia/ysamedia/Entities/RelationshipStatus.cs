using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class RelationshipStatus
    {
        public RelationshipStatus()
        {
            ChurchMember = new HashSet<ChurchMember>();
        }

        public int RelationshipId { get; set; }
        public string RelationshipCategory { get; set; }
        public int CategoryCounter { get; set; }

        public ICollection<ChurchMember> ChurchMember { get; set; }
    }
}
