using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Education
    {
        public Education()
        {
            Subject = new HashSet<Subject>();
        }

        public int EducationId { get; set; }
        public string QualificationName { get; set; }
        public string EducationType { get; set; }
        public bool Completed { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
        public ICollection<Subject> Subject { get; set; }
    }
}
