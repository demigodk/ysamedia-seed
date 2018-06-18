using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblAttributeUserBridge
    {
        public string UserId { get; set; }
        public int AttributeId { get; set; }
        public int Id { get; set; }

        public TblAttribute Attribute { get; set; }
        public TblUser User { get; set; }
    }
}
