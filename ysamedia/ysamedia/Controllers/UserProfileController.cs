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
       
        public IActionResult UserInformation()
        {
            return View();
        }
    }
}
