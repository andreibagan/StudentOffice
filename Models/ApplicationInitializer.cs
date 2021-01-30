using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StudentOffice.Models
{
    public class ApplicationInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "andrei.bagan2@mail.ru";
            string password = "petros123";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("абитуриент") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("абитуриент"));
            }
            if (await roleManager.FindByNameAsync("учащийся") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("учащийся"));
            }
            if (await roleManager.FindByNameAsync("преподаватель") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("преподаватель"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail, EmailConfirmed = true };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
