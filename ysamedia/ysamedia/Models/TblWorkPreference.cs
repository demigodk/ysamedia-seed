using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblWorkPreference
    {
        public int WorkPrefId { get; set; }
        public int PrefDepartment { get; set; }
        public string Availability { get; set; }
        public string UserId { get; set; }

        public TblDepartment PrefDepartmentNavigation { get; set; }
        public TblUser User { get; set; }
    }
}
