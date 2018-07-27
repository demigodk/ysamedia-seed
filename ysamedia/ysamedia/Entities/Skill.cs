using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string SkillDesc { get; set; }
        public int? SkillCatId { get; set; }
        public int? YearsExperience { get; set; }
        public string Proficiency { get; set; }
        public string UserId { get; set; }

        public SkillCategory SkillCat { get; set; }
        public User User { get; set; }
    }
}
