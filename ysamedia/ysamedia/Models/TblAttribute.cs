using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblAttribute
    {
        public TblAttribute()
        {
            TblAttributeUserBridge = new HashSet<TblAttributeUserBridge>();
        }

        public int AttributeId { get; set; }
        public string AttributeName { get; set; }

        public ICollection<TblAttributeUserBridge> TblAttributeUserBridge { get; set; }
    }
}
