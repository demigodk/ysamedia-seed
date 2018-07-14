using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public string Answer1 { get; set; }
        public int QuestionId { get; set; }
        public int ChurchMemberId { get; set; }

        public ChurchMember ChurchMember { get; set; }
        public Question Question { get; set; }
    }
}
