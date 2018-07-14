using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class RateAnswerUserBridge
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int AnswerId { get; set; }

        public RatingAnswer Answer { get; set; }
        public User User { get; set; }
    }
}
