﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ysamedia.Data;
using ysamedia.Models;
using ysamedia.Models.UserManagementViewModels;

namespace ysamedia.Controllers
{
    [Authorize(Roles = "Administrator, Admin")]
    public class UserManagementController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementController(ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {            
            var vm = new UserManagementIndexViewModel
            {
                Users = _dbContext.Users.OrderBy(u => u.DisplayName).Include(u => u.Roles).ToList()
            };
            
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole(string Id)
        {
            var user = await GetUserById(Id);

            var vm = new UserManagementAddRoleViewModel
            {
                Roles = GetAllRoles(),
                UserId = Id,
                Email = user.Email
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(UserManagementAddRoleViewModel rvm)
        {
            var user = await GetUserById(rvm.UserId);

            if (ModelState.IsValid)
            {                
                var result = await _userManager.AddToRoleAsync(user, rvm.NewRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }                
            }

            rvm.Email = user.Email;
            rvm.Roles = GetAllRoles();
            return View(rvm);          
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
           return await _userManager.FindByIdAsync(id);
        }

        private SelectList GetAllRoles() => new SelectList(_roleManager.Roles.OrderBy(r => r.Name));
    }
}
