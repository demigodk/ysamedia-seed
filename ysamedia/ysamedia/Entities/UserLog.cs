using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class UserLog
    {
        public int LogId { get; set; }
        public string UserId { get; set; }
        public int UserLogId { get; set; }
    }
}
