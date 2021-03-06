﻿using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class ScreeningAnswer
    {
        public int AnswerId { get; set; }
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }

        public ScreeningQuestion Question { get; set; }
        public User User { get; set; }
    }
}
