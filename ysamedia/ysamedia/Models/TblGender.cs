using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblGender
    {
        public TblGender()
        {
            TblUser = new HashSet<TblUser>();
        }

        public int GenderId { get; set; }
        public string Gname { get; set; }

        public ICollection<TblUser> TblUser { get; set; }
    }
}
