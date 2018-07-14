using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class NegativeAttribute
    {
        public NegativeAttribute()
        {
            NegAttributeUserBridge = new HashSet<NegAttributeUserBridge>();
        }

        public int AttributeId { get; set; }
        public string Attribute { get; set; }

        public ICollection<NegAttributeUserBridge> NegAttributeUserBridge { get; set; }
    }
}
