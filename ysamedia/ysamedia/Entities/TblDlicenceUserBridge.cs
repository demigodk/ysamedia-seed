using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblDlicenceUserBridge
    {
        public int LicenceId { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }

        public TblDriverLicence Licence { get; set; }
        public TblUser User { get; set; }
    }
}
