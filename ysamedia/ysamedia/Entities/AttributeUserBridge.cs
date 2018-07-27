using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class AttributeUserBridge
    {
        public string UserId { get; set; }
        public int AttributeId { get; set; }
        public int Id { get; set; }

        public PositiveAttribute Attribute { get; set; }
        public User User { get; set; }
    }
}
