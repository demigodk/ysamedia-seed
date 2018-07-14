using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Vacancy
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

        public Department Department { get; set; }
        public User FilledByNavigation { get; set; }
        public User PostedByNavigation { get; set; }
    }
}
