using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class DeptUserBrigdge
    {
        public int DepartmentId { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }

        public Department Department { get; set; }
        public User User { get; set; }
    }
}
