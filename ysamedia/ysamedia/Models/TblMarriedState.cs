using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblMarriedState
    {
        public TblMarriedState()
        {
            TblUser = new HashSet<TblUser>();
        }

        public int MstateId { get; set; }
        public string Mscategory { get; set; }
        public int CategoryCounter { get; set; }

        public ICollection<TblUser> TblUser { get; set; }
    }
}
