using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ysamedia.Entities;

namespace ysamedia.Models.TimeLogViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        [NotMapped]
        public IEnumerable<TblUser> UserCollection { get; set; }

        public string DisplayName { get; set; }
    }
}
