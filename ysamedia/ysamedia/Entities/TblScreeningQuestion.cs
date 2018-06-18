using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblScreeningQuestion
    {
        public TblScreeningQuestion()
        {
            TblScreeningAnswer = new HashSet<TblScreeningAnswer>();
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }

        public ICollection<TblScreeningAnswer> TblScreeningAnswer { get; set; }
    }
}
