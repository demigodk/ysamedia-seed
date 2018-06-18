using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblRoleClaim = new HashSet<TblRoleClaim>();
        }

        public string Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public ICollection<TblRoleClaim> TblRoleClaim { get; set; }
    }
}
