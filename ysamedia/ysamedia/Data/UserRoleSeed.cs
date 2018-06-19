using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using ysamedia.Models;

namespace ysamedia.Data
{
    public static class UserRoleSeed
    {
        public static async Task InitializeAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            // context.Database.EnsureCreated
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Administrator", "Admin", "Member", "Guest" };

            IdentityResult roleResult;

            foreach(var roleName in roleNames)
            {
                var roleExists = await RoleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }           
        }                    
    }
}
