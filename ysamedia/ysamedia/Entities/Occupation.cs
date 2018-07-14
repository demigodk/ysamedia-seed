using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Occupation
    {
        public Occupation()
        {
            ChurchMemberOccupationBridge = new HashSet<ChurchMemberOccupationBridge>();
        }

        public int OccupationId { get; set; }
        public string Occupation1 { get; set; }

        public ICollection<ChurchMemberOccupationBridge> ChurchMemberOccupationBridge { get; set; }
    }
}
