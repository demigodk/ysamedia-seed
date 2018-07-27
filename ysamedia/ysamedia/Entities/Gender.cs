using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class Gender
    {
        public Gender()
        {
            ChurchMember = new HashSet<ChurchMember>();
            User = new HashSet<User>();
        }

        public int GenderId { get; set; }
        public string Gname { get; set; }

        public ICollection<ChurchMember> ChurchMember { get; set; }
        public ICollection<User> User { get; set; }
    }
}
