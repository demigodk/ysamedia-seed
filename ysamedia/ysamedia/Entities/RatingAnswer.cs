using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class RatingAnswer
    {
        public RatingAnswer()
        {
            RateAnswerUserBridge = new HashSet<RateAnswerUserBridge>();
        }

        public int AnswerId { get; set; }
        public int Rating { get; set; }
        public int QuestionId { get; set; }

        public RatingQuestion Question { get; set; }
        public ICollection<RateAnswerUserBridge> RateAnswerUserBridge { get; set; }
    }
}
