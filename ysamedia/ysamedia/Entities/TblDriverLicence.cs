using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblDriverLicence
    {
        public TblDriverLicence()
        {
            TblDlicenceUserBridge = new HashSet<TblDlicenceUserBridge>();
        }

        public int LicenceId { get; set; }
        public string LicenceCode { get; set; }

        public ICollection<TblDlicenceUserBridge> TblDlicenceUserBridge { get; set; }
    }
}
