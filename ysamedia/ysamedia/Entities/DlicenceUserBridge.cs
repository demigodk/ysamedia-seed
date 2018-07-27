using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class DlicenceUserBridge
    {
        public int LicenceId { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }

        public DriverLicence Licence { get; set; }
        public User User { get; set; }
    }
}
