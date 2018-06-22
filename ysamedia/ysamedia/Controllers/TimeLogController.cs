using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ysamedia.Entities;
using ysamedia.Models.TimeLogViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ysamedia.Controllers
{
    //[Authorize(Roles = "Administrator, Admin")]    
    public class TimeLogController : Controller
    {

        private readonly ysamediaDbContext _context;

        public TimeLogController(ysamediaDbContext context)
        {            
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Index(string searchString)
        {            
            return View();
        }        
    }
}
