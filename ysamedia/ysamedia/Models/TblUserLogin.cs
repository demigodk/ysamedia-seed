using System;
using System.Collections.Generic;

namespace ysamedia.Models
{
    public partial class TblUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public TblUser User { get; set; }
    }
}
