using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ysamedia.Models.TimeLogViewModels;

namespace ysamedia.Controllers
{
    //[Authorize(Roles = "Administrator, Admin")]    
    public class TimeLogController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TimeLogViewModel model)
        {
            //ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {

            };

            // If we got this far, something failed, redisplay form
            return View();
        }
    }
}
