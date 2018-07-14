using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class NegAttributeUserBridge
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int AttributeId { get; set; }

        public NegativeAttribute Attribute { get; set; }
        public User User { get; set; }
    }
}
