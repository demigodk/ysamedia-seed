using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Department
    {
        public Department()
        {
            DeptUserBrigdge = new HashSet<DeptUserBrigdge>();
            Vacancy = new HashSet<Vacancy>();
            WorkPreference = new HashSet<WorkPreference>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentLeaderId { get; set; }
        public int? NumMembers { get; set; }
        public string DepartmentName { get; set; }

        public User DepartmentLeader { get; set; }
        public ICollection<DeptUserBrigdge> DeptUserBrigdge { get; set; }
        public ICollection<Vacancy> Vacancy { get; set; }
        public ICollection<WorkPreference> WorkPreference { get; set; }
    }
}
