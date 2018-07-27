using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class ScreeningQuestion
    {
        public ScreeningQuestion()
        {
            ScreeningAnswer = new HashSet<ScreeningAnswer>();
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }

        public ICollection<ScreeningAnswer> ScreeningAnswer { get; set; }
    }
}
