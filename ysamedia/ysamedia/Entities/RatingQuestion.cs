using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class RatingQuestion
    {
        public RatingQuestion()
        {
            RatingAnswer = new HashSet<RatingAnswer>();
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }

        public ICollection<RatingAnswer> RatingAnswer { get; set; }
    }
}
