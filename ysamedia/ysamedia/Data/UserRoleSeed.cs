using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using ysamedia.Models;

/// <summary>
/// @author     : Bondo Kalombo
/// @date       : 20-06-2018
/// </summary>
namespace ysamedia.Data
{
    /// <summary>
    /// This class is used to seed the database with 
    /// Roles
    /// It gets called in startup.cs
    /// </summary>
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
