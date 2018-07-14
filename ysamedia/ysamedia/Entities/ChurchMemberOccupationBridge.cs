using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class ChurchMemberOccupationBridge
    {
        public int Id { get; set; }
        public int ChurchMemberId { get; set; }
        public int OccupationId { get; set; }

        public ChurchMember ChurchMember { get; set; }
        public Occupation Occupation { get; set; }
    }
}
