using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblUserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public int UserRoleId { get; set; }

        public TblRole Role { get; set; }
        public TblUser User { get; set; }
    }
}
