using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class NextOfKin
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RelationshipType { get; set; }
        public int KinId { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkNumber { get; set; }

        public User User { get; set; }
    }
}
