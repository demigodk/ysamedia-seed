using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblDeptUserBrigdge = new HashSet<TblDeptUserBrigdge>();
            TblVacancy = new HashSet<TblVacancy>();
            TblWorkPreference = new HashSet<TblWorkPreference>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentLeaderId { get; set; }
        public int? NumMembers { get; set; }
        public string DepartmentName { get; set; }

        public TblUser DepartmentLeader { get; set; }
        public ICollection<TblDeptUserBrigdge> TblDeptUserBrigdge { get; set; }
        public ICollection<TblVacancy> TblVacancy { get; set; }
        public ICollection<TblWorkPreference> TblWorkPreference { get; set; }
    }
}
