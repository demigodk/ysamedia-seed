using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ysamedia.Models.MemberViewModels
{
    public class UserViewModel
    {
        [Key]
        public string UserId { get; set; }
       
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "Home Number")]
        [DataType(DataType.PhoneNumber)]
        public string HomeNumber { get; set; }

        [Display(Name = "Work Number")]
        [DataType(DataType.PhoneNumber)]
        public string WorkNumber { get; set; }

        [Display(Name = "Physical Address")]
        public string PhysicalAddress { get; set; }        
    }
}
