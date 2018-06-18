using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblSkillCategory
    {
        public TblSkillCategory()
        {
            TblSkill = new HashSet<TblSkill>();
        }

        public int SkillCatId { get; set; }
        public string CategoryName { get; set; }
        public int NumCount { get; set; }

        public ICollection<TblSkill> TblSkill { get; set; }
    }
}
