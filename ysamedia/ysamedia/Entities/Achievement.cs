using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Achievement
    {
        public int AchievementId { get; set; }
        public string AchievementName { get; set; }
        public DateTime? Date { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
