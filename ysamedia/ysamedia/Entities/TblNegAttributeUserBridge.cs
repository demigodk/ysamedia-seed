using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblNegAttributeUserBridge
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int AttributeId { get; set; }

        public TblNegativeAttribute Attribute { get; set; }
        public TblUser User { get; set; }
    }
}
