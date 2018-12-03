using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventuresWebApp.Data;
using EventuresWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EventuresWebApp.Middlewares
{
    public class SeedRolesAndAdminMiddleware
    {
        private readonly RequestDelegate next;
   
        public SeedRolesAndAdminMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext db, RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            if (!db.Roles.Any())
            {
               await roleManager.CreateAsync(new IdentityRole("Admin"));
               await roleManager.CreateAsync(new IdentityRole("User"));

            }

            if (!db.ApplicationUsers.Any())
            {
                var adminUser = new ApplicationUser()
                {
                        UserName = "admin",
                      Email = "admin@admin.com",
                    FirstName = "admin",
                    LastName = "admin",
                    UniqueCitizenNumber = "01234567890"
                };
                var addToDb = await userManager.CreateAsync(adminUser,"admin123");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            await this.next(context);
        }
    }
}
