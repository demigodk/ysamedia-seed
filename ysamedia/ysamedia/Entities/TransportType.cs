using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TransportType
    {
        public TransportType()
        {
            TransUserBridge = new HashSet<TransUserBridge>();
        }

        public int TransportId { get; set; }
        public string TransportName { get; set; }

        public ICollection<TransUserBridge> TransUserBridge { get; set; }
    }
}
