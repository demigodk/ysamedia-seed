using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblTransUserBridge
    {
        public int TransportId { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }

        public TblTransportType Transport { get; set; }
        public TblUser User { get; set; }
    }
}
