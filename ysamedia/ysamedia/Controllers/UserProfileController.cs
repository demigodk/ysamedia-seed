using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using ysamedia.Entities;

namespace ysamedia.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly ysamediaDbContext _context;
        private readonly string _userId;

        public UserProfileController(IHostingEnvironment hostingEnvironment, ysamediaDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _environment = hostingEnvironment;
            _context = context;
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _userId = userId;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Index([Bind("PhotoId,Photo,PhotoName,UserId")]TblPhoto photo)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;
                        var uploads = Path.Combine(_environment.WebRootPath, "uploads\\img\\members");
                       
                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse
                                (file.ContentDisposition).FileName.Trim('"');

                            System.Console.WriteLine(fileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                photo.PhotoId = 1;
                                photo.Photo = null;                                
                                photo.PhotoName = file.FileName;
                                photo.UserId = _userId;
                            }
                        }
                    }
                }

                _context.TblPhoto.Add(photo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Created");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View(photo);
        }

        public IActionResult Created()
        {
            return View();
        }
    }
}
