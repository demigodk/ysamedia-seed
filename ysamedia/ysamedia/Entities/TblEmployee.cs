using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblEmployee
    {
        public int EmployeeId { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public int OccupationId { get; set; }

        public TblOccupation Occupation { get; set; }
    }
}
