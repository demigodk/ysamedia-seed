using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class AgeGroup
    {
        public AgeGroup()
        {
            ChurchMember = new HashSet<ChurchMember>();
        }

        public int AgroupId { get; set; }
        public string AgeRange { get; set; }

        public ICollection<ChurchMember> ChurchMember { get; set; }
    }
}
