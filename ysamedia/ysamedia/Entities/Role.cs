using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Role
    {
        public Role()
        {
            RoleClaim = new HashSet<RoleClaim>();
        }

        public string Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public ICollection<RoleClaim> RoleClaim { get; set; }
    }
}
