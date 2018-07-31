using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ysamedia.Models.PhotoViewModels
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public byte[] Photo1 { get; set; }
        public string PhotoName { get; set; }
        public string UserId { get; set; }

        //public HttpPostedFileBase ImageFile { get; set; }
    }
}
