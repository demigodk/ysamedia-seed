using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblRateAnswerUserBridge
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int AnswerId { get; set; }

        public TblRatingAnswer Answer { get; set; }
        public TblUser User { get; set; }
    }
}
