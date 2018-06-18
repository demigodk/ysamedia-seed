using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblDeptUserBrigdge
    {
        public int DepartmentId { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }

        public TblDepartment Department { get; set; }
        public TblUser User { get; set; }
    }
}
