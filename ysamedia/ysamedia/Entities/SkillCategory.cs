using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class SkillCategory
    {
        public SkillCategory()
        {
            Skill = new HashSet<Skill>();
        }

        public int SkillCatId { get; set; }
        public string CategoryName { get; set; }
        public int NumCount { get; set; }

        public ICollection<Skill> Skill { get; set; }
    }
}
