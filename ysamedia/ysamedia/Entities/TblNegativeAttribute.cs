using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblNegativeAttribute
    {
        public TblNegativeAttribute()
        {
            TblNegAttributeUserBridge = new HashSet<TblNegAttributeUserBridge>();
        }

        public int AttributeId { get; set; }
        public string Attribute { get; set; }

        public ICollection<TblNegAttributeUserBridge> TblNegAttributeUserBridge { get; set; }
    }
}
