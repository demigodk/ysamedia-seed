using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblOccupation
    {
        public TblOccupation()
        {
            TblChurchMemberOccupationBridge = new HashSet<TblChurchMemberOccupationBridge>();
        }

        public int OccupationId { get; set; }
        public string Occupation { get; set; }

        public ICollection<TblChurchMemberOccupationBridge> TblChurchMemberOccupationBridge { get; set; }
    }
}
