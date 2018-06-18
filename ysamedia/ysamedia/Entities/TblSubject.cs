using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblSubject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int EducationId { get; set; }

        public TblEducation Education { get; set; }
    }
}
