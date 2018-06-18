using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblRatingQuestion
    {
        public TblRatingQuestion()
        {
            TblRatingAnswer = new HashSet<TblRatingAnswer>();
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }

        public ICollection<TblRatingAnswer> TblRatingAnswer { get; set; }
    }
}
