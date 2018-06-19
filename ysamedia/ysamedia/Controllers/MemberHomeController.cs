using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ysamedia.Controllers
{
    //[Authorize(Roles = "Member, Admin")]
    public class MemberHomeController : Controller
    {
        [Authorize(Roles = "Member")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult AccessGranted()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AllowAnonymous()
        {
            return View();
        }
    }
}
