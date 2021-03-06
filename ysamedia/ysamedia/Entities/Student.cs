﻿using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Category { get; set; }
        public string Course { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string InstitutionName { get; set; }
    }
}
