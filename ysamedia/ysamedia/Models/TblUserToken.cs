using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblUserToken
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int TokenId { get; set; }

        public TblUser User { get; set; }
    }
}
