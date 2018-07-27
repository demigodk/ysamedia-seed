using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class DriverLicence
    {
        public DriverLicence()
        {
            DlicenceUserBridge = new HashSet<DlicenceUserBridge>();
        }

        public int LicenceId { get; set; }
        public string LicenceCode { get; set; }

        public ICollection<DlicenceUserBridge> DlicenceUserBridge { get; set; }
    }
}
