using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StudentOffice.Models
{
    public class ApplicationInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationContext context)
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

            if(!context.DocumentTypes.Any())
            {
                await context.DocumentTypes.AddRangeAsync(new List<DocumentType>
                {
                    new DocumentType
                    {
                        Name = "Нет"
                    },
                    new DocumentType
                    {
                        Name = "Паспорт гражданина Республики Беларусь"
                    },
                    new DocumentType
                    {
                        Name = "Паспорт гражданина Российской Федерациии"
                    },
                    new DocumentType
                    {
                        Name = "Паспорт гражданина Республики Казахстан"
                    },
                    new DocumentType
                    {
                        Name = "Паспорт гражданина Республики Кыргызстан"
                    },
                    new DocumentType
                    {
                        Name = "Паспорт гражданина Республики Таджикистан"
                    },
                    new DocumentType
                    {
                        Name = "Вид на жительство в Республике Беларусь"

                    },
                    new DocumentType
                    {
                        Name = "Свидетельство о рождении"
                    },
                    new DocumentType
                    {
                        Name = "Удостоверение беженца"
                    },
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
