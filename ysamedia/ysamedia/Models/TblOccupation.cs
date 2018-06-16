using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblOccupation
    {
        public TblOccupation()
        {
            TblEmployee = new HashSet<TblEmployee>();
            TblStudent = new HashSet<TblStudent>();
        }

        public int OccupationId { get; set; }
        public string UserId { get; set; }

        public TblUser User { get; set; }
        public ICollection<TblEmployee> TblEmployee { get; set; }
        public ICollection<TblStudent> TblStudent { get; set; }
    }
}
