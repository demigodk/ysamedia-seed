using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblTransportType
    {
        public TblTransportType()
        {
            TblTransUserBridge = new HashSet<TblTransUserBridge>();
        }

        public int TransportId { get; set; }
        public string TransportName { get; set; }

        public ICollection<TblTransUserBridge> TblTransUserBridge { get; set; }
    }
}
