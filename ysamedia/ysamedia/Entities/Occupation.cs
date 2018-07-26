using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Occupation
    {
        public Occupation()
        {
            ChurchMember = new HashSet<ChurchMember>();
        }

        public int OccupationId { get; set; }
        public string Occupation1 { get; set; }

        public ICollection<ChurchMember> ChurchMember { get; set; }
    }
}
