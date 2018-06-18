using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ysamedia.Entities
{
    public partial class TblGender
    {
        public TblGender()
        {
            TblChurchMember = new HashSet<TblChurchMember>();
            TblUser = new HashSet<TblUser>();
        }

        [Key]
        public int GenderId { get; set; }
        public string Gname { get; set; }

        public ICollection<TblChurchMember> TblChurchMember { get; set; }
        public ICollection<TblUser> TblUser { get; set; }
    }
}
