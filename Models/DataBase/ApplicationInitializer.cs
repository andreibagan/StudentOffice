using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace StudentOffice.Models.DataBase
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
            }

            if (!context.Specialties.Any())
            {
                await context.Specialties.AddRangeAsync(new List<Specialty>
                {
                    new Specialty
                    {
                        Branch = Branch.Correspondence,
                        Name = "Правоведение",
                    },
                    new Specialty
                    {
                        Branch = Branch.Correspondence,
                        Name = "Бухгалтерский учёт, анализ и контроль",
                    },
                    new Specialty
                    {
                        Branch = Branch.Daytime,
                        Name = "Программное обеспечение информационных технологий",
                    },
                    new Specialty
                    {
                        Branch = Branch.Daytime,
                        Name = "Операционная деятельность в логистике",
                    },
                    new Specialty
                    {
                        Branch = Branch.Daytime,
                        Name = "Правоведение",
                    },
                    new Specialty
                    {
                        Branch = Branch.Daytime,
                        Name = "Бухгалтерский учёт, анализ и контроль",
                    },
                });
            }

            if (!context.TypeOfSpravkas.Any())
            {
                await context.TypeOfSpravkas.AddRangeAsync(new List<TypeOfSpravka>
                {
                    new TypeOfSpravka
                    {
                        TypeOfSpravkaName = "Об обучении"
                    },
                    new TypeOfSpravka
                    {
                         TypeOfSpravkaName = "Военкомат"
                    },
                    new TypeOfSpravka
                    {
                         TypeOfSpravkaName = "Райсобес"
                    },
                    new TypeOfSpravka
                    {
                         TypeOfSpravkaName = "ЖКХ"
                    },
                });
            }

            if (!context.Groups.Any())
            {
                await context.Groups.AddRangeAsync(new List<Group>
                {
                    new Group
                    {
                        GroupName = "409",
                        YearOfFormation = new DateTime(2000, 10, 3),
                        ExpirationDate = new DateTime(2004, 10, 3),
                    },
                    new Group
                    {
                        GroupName = "309",
                        YearOfFormation = new DateTime(2001, 10, 3),
                        ExpirationDate = new DateTime(2005, 11, 3),
                    },

                });
            }

            await context.SaveChangesAsync();
            //if (!context.StreetTypes.Any())
            //{
            //    await context.StreetTypes.AddRangeAsync(new List<StreetType>
            //    {
            //        new StreetType
            //        {
            //            StreetTypeName = "Аллея"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Бульвар"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Въезд"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Квартал"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Микрорайон"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Набережная"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Переулок"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Площадь"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Проезд"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Станция"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Территория"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Тракт"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Тупик"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Улица"
            //        },
            //        new StreetType
            //        {
            //            StreetTypeName = "Шоссе"
            //        },
            //    });
            //}

            //if (!context.TypeLocalities.Any())
            //{
            //    await context.TypeLocalities.AddRangeAsync(new List<TypeLocality>
            //    {
            //        new TypeLocality
            //        {
            //            TypeLocalityName = "Агрогородок"
            //        },
            //        new TypeLocality
            //        {
            //            TypeLocalityName = "Город"
            //        },
            //        new TypeLocality
            //        {
            //            TypeLocalityName = "Городской поселок"
            //        },
            //        new TypeLocality
            //        {
            //            TypeLocalityName = "Деревня"
            //        },
            //        new TypeLocality
            //        {
            //            TypeLocalityName = "Курортный поселок"
            //        },
            //        new TypeLocality
            //        {
            //            TypeLocalityName = "Поселок"
            //        },
            //        new TypeLocality
            //        {
            //            TypeLocalityName = "Рабочий поселок"
            //        },
            //        new TypeLocality
            //        {
            //            TypeLocalityName = "Село"
            //        },
            //        new TypeLocality
            //        {
            //            TypeLocalityName = "Сельский населенный пункт"
            //        },
            //        new TypeLocality
            //        {
            //            TypeLocalityName = "Хутор"
            //        },
            //    }); 
            //}
           

        }
    }
}
