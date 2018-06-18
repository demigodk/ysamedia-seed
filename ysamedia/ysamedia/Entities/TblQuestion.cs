using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblQuestion
    {
        public TblQuestion()
        {
            TblAnswer = new HashSet<TblAnswer>();
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }

        public ICollection<TblAnswer> TblAnswer { get; set; }
    }
}
