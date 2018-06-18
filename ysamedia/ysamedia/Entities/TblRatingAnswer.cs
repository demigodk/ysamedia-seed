using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblRatingAnswer
    {
        public TblRatingAnswer()
        {
            TblRateAnswerUserBridge = new HashSet<TblRateAnswerUserBridge>();
        }

        public int AnswerId { get; set; }
        public int Rating { get; set; }
        public int QuestionId { get; set; }

        public TblRatingQuestion Question { get; set; }
        public ICollection<TblRateAnswerUserBridge> TblRateAnswerUserBridge { get; set; }
    }
}
