using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Photo
    {
        public int PhotoId { get; set; }
        public byte[] Photo1 { get; set; }
        public string PhotoName { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
