using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ysamedia.Entities;
using ysamedia.Models.UserViewModels;

namespace ysamedia.Controllers
{
    public class UsersController : Controller
    {
        private readonly ysamediaDbContext _context;

        public UsersController(ysamediaDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.SingleOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["Address"] = user.PhysicalAddress;
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "Gname", user.GenderId);

            UserViewModel viewModel = new UserViewModel
            {
                UserId = user.UserId,
                AccessFailedCount = user.AccessFailedCount,
                ConcurrencyStamp = user.ConcurrencyStamp,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                LockoutEnabled = user.LockoutEnabled,
                LockoutEnd = user.LockoutEnd,
                NormalizedEmail = user.NormalizedEmail,
                NormalizedUserName = user.NormalizedUserName,
                PasswordHash = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                SecurityStamp = user.SecurityStamp,
                TwoFactorEnabled = user.TwoFactorEnabled,
                UserName = user.UserName,
                Discriminator = user.Discriminator,
                DisplayName = user.DisplayName,
                DateJoinedDept = user.DateJoinedDept,
                DateOfBirth = user.DateOfBirth,
                Surname = user.Surname,
                FirstName = user.FirstName,
                HomeNumber = user.HomeNumber,
                WorkNumber = user.WorkNumber,
                PhysicalAddress = user.PhysicalAddress,
                Street = user.Street,
                City = user.City,
                Province = user.Province,
                PostalCode = user.PostalCode,
                GenderId = user.GenderId,
                Approved = user.Approved,
                DriverLicence = user.DriverLicence
            };

            return View(viewModel);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,AccessFailedCount,ConcurrencyStamp,Email,EmailConfirmed,LockoutEnabled,LockoutEnd,NormalizedEmail,NormalizedUserName,PasswordHash,PhoneNumber,PhoneNumberConfirmed,SecurityStamp,TwoFactorEnabled,UserName,Discriminator,DisplayName,DateJoinedDept,DateOfBirth,Surname,FirstName,HomeNumber,WorkNumber,PhysicalAddress,GenderId,Approved,DriverLicence,Street,City,Province,PostalCode")] UserViewModel viewModel)
        {           
            if (id != viewModel.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {                
                User user = new User
                {
                    UserId = viewModel.UserId,
                    AccessFailedCount = viewModel.AccessFailedCount,
                    ConcurrencyStamp = viewModel.ConcurrencyStamp,
                    Email = viewModel.Email,
                    EmailConfirmed = viewModel.EmailConfirmed,
                    LockoutEnabled = viewModel.LockoutEnabled,
                    LockoutEnd = viewModel.LockoutEnd,
                    NormalizedEmail = viewModel.NormalizedEmail,
                    NormalizedUserName = viewModel.NormalizedUserName,
                    PasswordHash = viewModel.PasswordHash,
                    PhoneNumber = viewModel.PhoneNumber,
                    PhoneNumberConfirmed = viewModel.PhoneNumberConfirmed,
                    SecurityStamp = viewModel.SecurityStamp,
                    TwoFactorEnabled = viewModel.TwoFactorEnabled,
                    UserName = viewModel.UserName,
                    Discriminator = viewModel.Discriminator,
                    DisplayName = viewModel.DisplayName,
                    DateJoinedDept = viewModel.DateJoinedDept,
                    DateOfBirth = viewModel.DateOfBirth,
                    Surname = viewModel.Surname,
                    FirstName = viewModel.FirstName,
                    HomeNumber = viewModel.HomeNumber,
                    WorkNumber = viewModel.WorkNumber,
                    PhysicalAddress = viewModel.PhysicalAddress,
                    Street = viewModel.Street,
                    City = viewModel.City,
                    Province = viewModel.Province,
                    PostalCode = viewModel.PostalCode,                    
                    GenderId = viewModel.GenderId,
                    Approved = viewModel.Approved,
                    DriverLicence = viewModel.DriverLicence
                };

                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               
                return View();
            }

            ViewData["Address"] = viewModel.Street + " " + viewModel.City + " " + viewModel.Province + " " + viewModel.PostalCode;
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "Gname", viewModel.GenderId);
            return View(viewModel);
        }
        
        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
