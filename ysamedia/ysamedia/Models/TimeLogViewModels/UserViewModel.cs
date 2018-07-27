using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public IEnumerable<User> UserCollection { get; set; }

        public string DisplayName { get; set; }
    }
}
