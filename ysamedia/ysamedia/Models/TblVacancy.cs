using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblVacancy
    {
        public int VacancyId { get; set; }
        public int DepartmentId { get; set; }
        public string VacancyName { get; set; }
        public string VacancyDescription { get; set; }
        public DateTime DatePosted { get; set; }
        public string PostedBy { get; set; }
        public bool? VacancyFilled { get; set; }
        public string FilledBy { get; set; }
        public bool? VacancyActive { get; set; }

        public TblDepartment Department { get; set; }
        public TblUser FilledByNavigation { get; set; }
        public TblUser PostedByNavigation { get; set; }
    }
}
