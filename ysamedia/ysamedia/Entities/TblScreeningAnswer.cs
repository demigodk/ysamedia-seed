using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblScreeningAnswer
    {
        public int AnswerId { get; set; }
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }

        public TblScreeningQuestion Question { get; set; }
        public TblUser User { get; set; }
    }
}
