using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using ysamedia.Entities;
using ysamedia.Models.UserScreeningViewModels;

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
                // Get the maximum PK in tblPhoto
                int maxPhotoId = 0;

                if (_context.TblPhoto.Any())
                {
                    maxPhotoId = _context.TblPhoto.Max(t => t.PhotoId);
                }

                var files = HttpContext.Request.Form.Files;
                string fileName = null;

                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;
                        var uploads = Path.Combine(_environment.WebRootPath, "uploads\\img\\members");
                       
                        if (file.Length > 0)
                        {
                            //var fileName = ContentDispositionHeaderValue.Parse
                            //    (file.ContentDisposition).FileName.Trim('"');

                            fileName = ContentDispositionHeaderValue.Parse
                                (file.ContentDisposition).FileName.Trim('"');

                            //System.Console.WriteLine(fileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                photo.PhotoId = (maxPhotoId + 1);
                                photo.Photo = null;                                
                                photo.PhotoName = file.FileName;
                                photo.UserId = _userId;
                            }
                        }
                    }
                    ViewData["fileLocation"] = "\\uploads\\img\\members\\" + fileName;
                }

                _context.TblPhoto.Add(photo);
                await _context.SaveChangesAsync();
                //return RedirectToAction("Created");
                return View();
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View(photo);
        }
               
        public IActionResult Created()
        {
                                    
            //string photoName = null;
            string photoLocation = null;

            List<string> photoName = new List<string>();

            if (_context.TblPhoto.Any())
            {

                // This returns a list of tblPhoto.PhotoName items
                photoName = (from u in _context.TblPhoto
                             where u.UserId == _userId
                             select u.PhotoName).ToList();

                // To get the PhotoName, I loop through the array which should have one item and assign that 
                // name to tempName, (there should be a better way to do this, but I don't have internet access)
                string tempName = null;

                foreach (var item in photoName)
                {
                    tempName = item;
                }

                photoLocation = "\\uploads\\img\\members\\" + tempName;
            }
            else
            {
                photoLocation = "\\images\\" + "avatar_2x.png";
            }

            ViewData["fName"] = photoLocation;
            ViewData["fileLocation"] = photoLocation;

            return View();
        }

        public IActionResult UserInformation()
        {
            return View();
        }
    }
}
