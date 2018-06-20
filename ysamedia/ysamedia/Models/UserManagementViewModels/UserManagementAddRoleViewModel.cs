using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ysamedia.Models.UserManagementViewModels
{
    public class UserManagementAddRoleViewModel
    {
        public string UserId { get; set; }
        public string NewRole { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
        public string Email { get; set; }
    }
}
