using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblAgeGroup
    {
        public TblAgeGroup()
        {
            TblUser = new HashSet<TblUser>();
        }

        public int AgroupId { get; set; }
        public string AgeRange { get; set; }

        public ICollection<TblUser> TblUser { get; set; }
    }
}
