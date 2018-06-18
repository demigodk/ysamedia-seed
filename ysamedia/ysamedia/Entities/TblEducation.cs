using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblEducation
    {
        public TblEducation()
        {
            TblSubject = new HashSet<TblSubject>();
        }

        public int EducationId { get; set; }
        public string QualificationName { get; set; }
        public string EducationType { get; set; }
        public bool Completed { get; set; }
        public string UserId { get; set; }

        public TblUser User { get; set; }
        public ICollection<TblSubject> TblSubject { get; set; }
    }
}
