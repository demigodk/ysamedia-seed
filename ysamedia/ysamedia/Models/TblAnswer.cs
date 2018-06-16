using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblAnswer
    {
        public int AnswerId { get; set; }
        public string Answer { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }

        public TblQuestion Question { get; set; }
        public TblUser User { get; set; }
    }
}
