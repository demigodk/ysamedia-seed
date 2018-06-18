using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblAnswer
    {
        public int AnswerId { get; set; }
        public string Answer { get; set; }
        public int QuestionId { get; set; }
        public int ChurchMemberId { get; set; }

        public TblChurchMember ChurchMember { get; set; }
        public TblQuestion Question { get; set; }
    }
}
