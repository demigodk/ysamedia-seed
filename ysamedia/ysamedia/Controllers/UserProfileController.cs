using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpPost]
        public IActionResult Index(string name)
        {
            var newFileName = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Getting FileName
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        // Assigning Unique FileName (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        // Getting file Extension
                        var FileExtension = Path.GetExtension(fileName);

                        // Concating FileName + FileExtension
                        newFileName = myUniqueFileName + FileExtension;

                        // Combines two strings into a path
                        fileName = Path.Combine(_environment.WebRootPath, "uploads\\img\\members") + $@"\{newFileName}";

                        // Path to store in database
                        PathDB = "uploads\\img\\members\\" + newFileName;

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }


                        // Writing to the detabase
                        var photoName2 = _context.Photo.FirstOrDefault(p => p.UserId == _userId);

                        if (photoName2 == null)
                        {
                            // If no photo found (insert one)
                            Photo photo = new Photo
                            {
                                Photo1 = null,
                                PhotoName = PathDB,
                                UserId = _userId
                            };

                            _context.Photo.Add(photo);
                            _context.SaveChanges();
                        }
                        else
                        {                          
                            // If the user already has a photo then update the record
                            photoName2.PhotoName = PathDB;
                            _context.Photo.Update(photoName2);
                            _context.SaveChanges();
                        }                                             
                    }
                }
            }

            return View();
            
        }
        
        //public async Task<IActionResult> Index([Bind("PhotoId,Photo,PhotoName,UserId")]Photo photo)
        //{
        //    if (ModelState.IsValid)
        //    {                
        //        var files = HttpContext.Request.Form.Files;
        //        string fileName = null;
        //        //string nameofphoto = null;

        //        foreach (var Image in files)
        //        {
        //            if (Image != null && Image.Length > 0)
        //            {
        //                var file = Image;
        //                var uploads = Path.Combine(_environment.WebRootPath, "uploads\\img\\members");

        //                if (file.Length > 0)
        //                {
        //                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

        //                    //nameofphoto = Path.GetFileName(file.FileName);

        //                    //System.Console.WriteLine(fileName);
        //                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
        //                    {
        //                        await file.CopyToAsync(fileStream);                               
        //                        photo.Photo1 = null;
        //                        photo.PhotoName = fileName;
        //                        photo.UserId = _userId;
        //                    }
        //                }
        //            }
        //            ViewData["name"] = fileName;
        //            //ViewData["fileLocation"] = "\\uploads\\img\\members\\" + fileName;
        //        }

        //        _context.Photo.Add(photo);
        //        await _context.SaveChangesAsync();                
        //        return View();
        //    }
        //    else
        //    {
        //        var errors = ModelState.Values.SelectMany(v => v.Errors);
        //    }
        //    return View(photo);
        //}

        //public IActionResult Created()
        //{

        //    //string photoName = null;
        //    string photoLocation = null;

        //    List<string> photoName = new List<string>();

        //    if (_context.Photo.Any())
        //    {

        //        // This returns a list of Photo.PhotoName items
        //        photoName = (from u in _context.Photo
        //                     where u.UserId == _userId
        //                     select u.PhotoName).ToList();

        //        // To get the PhotoName, I loop through the array which should have one item and assign that 
        //        // name to tempName, (there should be a better way to do this, but I don't have internet access)
        //        string tempName = null;

        //        foreach (var item in photoName)
        //        {
        //            tempName = item;
        //        }

        //        photoLocation = "\\uploads\\img\\members\\" + tempName;
        //    }
        //    else
        //    {
        //        photoLocation = "\\images\\" + "avatar_2x.png";
        //    }

        //    ViewData["fName"] = photoLocation;
        //    ViewData["fileLocation"] = photoLocation;

        //    return View();
        //}

        public IActionResult UserInformation()
        {
            return View();
        }
    }
}
