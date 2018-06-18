using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblOccupation
    {
        public TblOccupation()
        {
            TblEmployee = new HashSet<TblEmployee>();
            TblStudent = new HashSet<TblStudent>();
        }

        public int OccupationId { get; set; }
        public int ChurchMemberId { get; set; }

        public TblChurchMember ChurchMember { get; set; }
        public ICollection<TblEmployee> TblEmployee { get; set; }
        public ICollection<TblStudent> TblStudent { get; set; }
    }
}
