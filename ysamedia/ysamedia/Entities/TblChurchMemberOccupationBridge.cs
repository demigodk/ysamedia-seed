using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblChurchMemberOccupationBridge
    {
        public int Id { get; set; }
        public int ChurchMemberId { get; set; }
        public int OccupationId { get; set; }

        public TblChurchMember ChurchMember { get; set; }
        public TblOccupation Occupation { get; set; }
    }
}
