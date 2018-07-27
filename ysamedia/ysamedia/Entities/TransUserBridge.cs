using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TransUserBridge
    {
        public int TransportId { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }

        public TransportType Transport { get; set; }
        public User User { get; set; }
    }
}
