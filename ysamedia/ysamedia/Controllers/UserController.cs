using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ysamedia.Entities;

namespace ysamedia.Controllers
{
    public class UserController : Controller
    {
        private ysamediaDbContext db = new ysamediaDbContext();

        public IActionResult Index()
        {
            var user = db.TblUser.FirstOrDefault();
            return View(user);
        }

        public IActionResult UserList()
        {
            ICollection<TblUser> users = db.TblUser.ToList();
            return View(users);
        }
    }
}
