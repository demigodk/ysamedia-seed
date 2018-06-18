using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblPhoto
    {
        public int PhotoId { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoName { get; set; }
        public string UserId { get; set; }

        public TblUser User { get; set; }
    }
}
