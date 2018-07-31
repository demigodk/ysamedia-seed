using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ysamedia.Controllers
{
    public class PhotoController : Controller
    {
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
    }
}