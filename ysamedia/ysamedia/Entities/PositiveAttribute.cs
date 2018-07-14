using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class PositiveAttribute
    {
        public PositiveAttribute()
        {
            AttributeUserBridge = new HashSet<AttributeUserBridge>();
        }

        public int AttributeId { get; set; }
        public string AttributeName { get; set; }

        public ICollection<AttributeUserBridge> AttributeUserBridge { get; set; }
    }
}
