using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int EducationId { get; set; }

        public Education Education { get; set; }
    }
}
