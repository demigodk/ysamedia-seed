using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class WorkPreference
    {
        public int WorkPrefId { get; set; }
        public int PrefDepartment { get; set; }
        public string Availability { get; set; }
        public string UserId { get; set; }

        public Department PrefDepartmentNavigation { get; set; }
        public User User { get; set; }
    }
}
