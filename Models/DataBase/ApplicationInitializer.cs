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

            if (!userManager.Users.Any())
            {
                User user1 = new User { Email = "Apetenok@mail.ru", UserName = "Apetenok@mail.ru", FullName = "Апетенок О.Н.", EmailConfirmed = true };
                IdentityResult result1 = await userManager.CreateAsync(user1, "qwerty123");
                if (result1.Succeeded)
                {
                    await userManager.AddToRoleAsync(user1, "преподаватель");
                }

                User user2 = new User { Email = "Ciganok@mail.ru", UserName = "Ciganok@mail.ru", FullName = "Цыганок О.Ч.", EmailConfirmed = true };
                IdentityResult result2 = await userManager.CreateAsync(user2, "qwerty123");
                if (result2.Succeeded)
                {
                    await userManager.AddToRoleAsync(user2, "преподаватель");
                }

                User user3 = new User { Email = "Skadorva@mail.ru", UserName = "Skadorva@mail.ru", FullName = "Скадорва Е.О.", EmailConfirmed = true };
                IdentityResult result3 = await userManager.CreateAsync(user3, "qwerty123");
                if (result3.Succeeded)
                {
                    await userManager.AddToRoleAsync(user3, "преподаватель");
                }

                User user4 = new User { Email = "Vasilevich@mail.ru", UserName = "Vasilevich@mail.ru", FullName = "Василевич А.Е.", EmailConfirmed = true };
                IdentityResult result4 = await userManager.CreateAsync(user4, "qwerty123");
                if (result4.Succeeded)
                {
                    await userManager.AddToRoleAsync(user4, "преподаватель");
                }

                User user5 = new User { Email = "Manuk@mail.ru", UserName = "Manuk@mail.ru", FullName = "Манюк М.Г.", EmailConfirmed = true };
                IdentityResult result5 = await userManager.CreateAsync(user5, "qwerty123");
                if (result5.Succeeded)
                {
                    await userManager.AddToRoleAsync(user5, "преподаватель");
                }

                User user6 = new User { Email = "Klincevich@mail.ru", UserName = "Klincevich@mail.ru", FullName = "Клинцевич А.И.", EmailConfirmed = true };
                IdentityResult result6 = await userManager.CreateAsync(user6, "qwerty123");
                if (result6.Succeeded)
                {
                    await userManager.AddToRoleAsync(user6, "преподаватель");
                }
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

            

            if (!context.DocumentTypes.Any())
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

                    new Group
                    {
                        GroupName = "305",
                        YearOfFormation = new DateTime(2000, 10, 3),
                        ExpirationDate = new DateTime(2004, 10, 3),
                    },
                });
            }

            if (!context.Semesters.Any())
            {
                await context.Semesters.AddRangeAsync(new List<Semester>
                {
                    new Semester
                    {
                        SemesterNumber = 1
                    },
                    new Semester
                    {
                        SemesterNumber = 2
                    },
                    new Semester
                    {
                        SemesterNumber = 3
                    },
                    new Semester
                    {
                        SemesterNumber = 4
                    },
                    new Semester
                    {
                        SemesterNumber = 5
                    },
                    new Semester
                    {
                        SemesterNumber = 6
                    },
                    new Semester
                    {
                        SemesterNumber = 7
                    },
                    new Semester
                    {
                        SemesterNumber = 8
                    },
                    new Semester
                    {
                        SemesterNumber = 9
                    },
                    new Semester
                    {
                        SemesterNumber = 10
                    },

                });
            }

            if (!context.Audiences.Any())
            {
                await context.Audiences.AddRangeAsync(new List<Audience>
                {
                    new Audience
                    {
                        AudienceName = "Компьютерная аудитория",
                        AudienceNumber = 42
                    },
                    new Audience
                    {
                        AudienceName = "Компьютерная аудитория",
                        AudienceNumber = 35
                    },
                    new Audience
                    {
                        AudienceName = "Компьютерная аудитория",
                        AudienceNumber = 31
                    },
                    new Audience
                    {
                        AudienceName = "Компьютерная аудитория",
                        AudienceNumber = 32
                    },
                    new Audience
                    {
                        AudienceName = "Компьютерная аудитория",
                        AudienceNumber = 33
                    },
                    new Audience
                    {
                        AudienceName = "Компьютерная аудитория",
                        AudienceNumber = 43
                    },
                });
            }

            if (!context.Disciplines.Any())
            {
                await context.Disciplines.AddRangeAsync(new List<Discipline>
                {
                    new Discipline
                    {
                        DisciplineName = "Бухгалтерский учёт",
                        DisciplineShortName = "Бух.уч"
                    },
                    new Discipline
                    {
                        DisciplineName = "Белорусский язык (профессиональная лексика)",
                        DisciplineShortName = "Бел.яз.(проф.лек.)"
                    },
                    new Discipline
                    {
                        DisciplineName = "Информатика",
                        DisciplineShortName = "Информатика"
                    },
                    new Discipline
                    {
                        DisciplineName = "Биология",
                        DisciplineShortName = "Биология"
                    },
                    new Discipline
                    {
                        DisciplineName = "География",
                        DisciplineShortName = "География"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы права",
                        DisciplineShortName = "Осн.права"
                    },
                    new Discipline
                    {
                        DisciplineName = "Базы данных и системы управления базами данных",
                        DisciplineShortName = "БДиСУБД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Сит. операционных систем",
                        DisciplineShortName = "Сит.опер.сист."
                    },
                    new Discipline
                    {
                        DisciplineName = "ТРПО",
                        DisciplineShortName = "ТРПО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Физкультура",
                        DisciplineShortName = "Физ."
                    },
                    new Discipline
                    {
                        DisciplineName = "Программные средства и создание интернет приложений",
                        DisciplineShortName = "Прогр.ср-ва созд.инт"
                    },
                    new Discipline
                    {
                        DisciplineName = "Защита компьютерной информации",
                        DisciplineShortName = "Защита комп.инф."
                    },
                    new Discipline
                    {
                        DisciplineName = "Сит. операционных систем",
                        DisciplineShortName = "Сит.опер.сист."
                    },
                });
            }

            await context.SaveChangesAsync();


            if (!context.Omissions.Any())
            {
                await context.Omissions.AddRangeAsync(new List<Omission>
                {
                   new Omission
                   {
                       Total = 33,
                       Disrespectful = 0
                   },
                   new Omission
                   {
                       Total = 40,
                       Disrespectful = 5
                   },
                   new Omission
                   {
                       Total = 1,
                       Disrespectful = 1
                   },
                   new Omission
                   {
                       Total = 0,
                       Disrespectful = 0
                   },
                   new Omission
                   {
                       Total = 2,
                       Disrespectful = 0
                   },
                });
            }

            if (!context.Exams.Any())
            {
                await context.Exams.AddRangeAsync(new List<Exam>
                {
                   new Exam
                   {
                       ExamName = "Математика",
                   },
                   new Exam
                   {
                        ExamName = "Компьютерная графика",
                   },
                });
            }

            await context.SaveChangesAsync();

            if (!context.GroupExams.Any())
            {
                await context.GroupExams.AddRangeAsync(new List<GroupExam>
                {
                   new GroupExam
                   {
                       GroupId = 3,
                       ExamId = 1
                   },
                   new GroupExam
                   {
                       GroupId = 3,
                       ExamId = 2
                   },
                });
            }

            if (!context.MarkLogs.Any())
            {
                await context.MarkLogs.AddRangeAsync(new List<MarkLog>
                {
                   new MarkLog
                   {
                       SemesterId = 1,
                   },
                });
            }

            await context.SaveChangesAsync();

            if (!context.MarkUsers.Any())
            {
                await context.MarkUsers.AddRangeAsync(new List<MarkUser>
                {
                   new MarkUser
                   {
                       UserId = "4ac1a332-7bc9-4592-a955-8128cac4b874",
                       OmissionId = 1,
                       MarkLogId = 1
                   },
                   new MarkUser
                   {
                       UserId = "1d8820a0-6ac9-4bd2-b95c-917d6616751b",
                       OmissionId = 2,
                       MarkLogId = 1
                   },
                }); 
            }

            if (!context.GroupDisciplines.Any())
            {
                await context.GroupDisciplines.AddRangeAsync(new List<GroupDiscipline>
                {
                   new GroupDiscipline
                   {
                       GroupId = 3,
                       DisciplineId = 1,
                   },
                   new GroupDiscipline
                   {
                       GroupId = 3,
                       DisciplineId = 2,
                   },
                   new GroupDiscipline
                   {
                       GroupId = 3,
                       DisciplineId = 3,
                   },
                   new GroupDiscipline
                   {
                       GroupId = 3,
                       DisciplineId = 4,
                   },
                   new GroupDiscipline
                   {
                       GroupId = 3,
                       DisciplineId = 5,
                   },
                   new GroupDiscipline
                   {
                       GroupId = 3,
                       DisciplineId = 6,
                   },
                   new GroupDiscipline
                   {
                       GroupId = 3,
                       DisciplineId = 7,
                   },
                   new GroupDiscipline
                   {
                       GroupId = 3,
                       DisciplineId = 8,
                   },
                   new GroupDiscipline
                   {
                       GroupId = 3,
                       DisciplineId = 9,
                   },
                   new GroupDiscipline
                   {
                       GroupId = 3,
                       DisciplineId = 10,
                   },
                });
            }

            await context.SaveChangesAsync();

            if (!context.Marks.Any())
            {
                await context.Marks.AddRangeAsync(new List<Mark>
                {
                   new Mark
                   {
                       MarkUserId = 1,
                       GroupDisciplineId = 1,
                       MarkValue = "5"
                   },
                   new Mark
                   {
                       MarkUserId = 1,
                       GroupDisciplineId = 2,
                       MarkValue = "7"
                   },
                   new Mark
                   {
                       MarkUserId = 1,
                       GroupDisciplineId = 3,
                       MarkValue = "6"
                   },
                   new Mark
                   {
                       MarkUserId = 1,
                       GroupDisciplineId = 4,
                       MarkValue = "8"
                   },
                   new Mark
                   {
                       MarkUserId = 1,
                       GroupDisciplineId = 5,
                       MarkValue = "2"
                   },
                   new Mark
                   {
                       MarkUserId = 1,
                       GroupDisciplineId = 6,
                       MarkValue = "8"
                   },
                   new Mark
                   {
                       MarkUserId = 1,
                       GroupDisciplineId = 7,
                       MarkValue = "5"
                   },
                   new Mark
                   {
                       MarkUserId = 2,
                       GroupDisciplineId = 1,
                       MarkValue = "3"
                   },
                   new Mark
                   {
                       MarkUserId = 2,
                       GroupDisciplineId = 2,
                       MarkValue = "7"
                   },
                   new Mark
                   {
                       MarkUserId = 2,
                       GroupDisciplineId = 3,
                       MarkValue = "9"
                   },
                   new Mark
                   {
                       MarkUserId = 2,
                       GroupDisciplineId = 4,
                       MarkValue = "5"
                   },
                   new Mark
                   {
                       MarkUserId = 2,
                       GroupDisciplineId = 5,
                       MarkValue = "4"
                   },
                   new Mark
                   {
                       MarkUserId = 2,
                       GroupDisciplineId = 6,
                       MarkValue = "4"
                   },
                   new Mark
                   {
                       MarkUserId = 2,
                       GroupDisciplineId = 7,
                       MarkValue = "6"
                   },
                });
            }

            if (!context.MarkExams.Any())
            {
                await context.MarkExams.AddRangeAsync(new List<MarkExam>
                {
                   new MarkExam
                   {
                       MarkValue = 7,
                       MarkUserId = 1,
                       GroupExamId = 1
                   },
                   new MarkExam
                   {
                       MarkValue = 5,
                       MarkUserId = 1,
                       GroupExamId = 2
                   },
                   new MarkExam
                   {
                       MarkValue = 8,
                       MarkUserId = 2,
                       GroupExamId = 1
                   },
                   new MarkExam
                   {
                       MarkValue = 9,
                       MarkUserId = 2,
                       GroupExamId = 2
                   },
                });
            }

            await context.SaveChangesAsync();
            //if (!context.TimeWindows.Any())
            //{
            //    await context.TimeWindows.AddRangeAsync(new List<TimeWindow>
            //    {
            //        new TimeWindow
            //        {
            //            TimeWindowName = "123",
            //            FirstHalf = true,
            //            SecondHalf = false
            //        },
            //    });
            //}

            //await context.SaveChangesAsync();

            //if (!context.TimeTables.Any())
            //{
            //    await context.TimeTables.AddRangeAsync(new List<TimeTable>
            //    {
            //        new TimeTable
            //        {
            //            DateTime = DateTime.Now,
            //            DayNumber = 18,
            //            PatternType = "Рабочий",
            //            SemesterId = 1
            //        },
            //    });
            //}

            //await context.SaveChangesAsync();

            //if (!context.TimeTableGroups.Any())
            //{
            //    await context.TimeTableGroups.AddRangeAsync(new List<TimeTableGroup>
            //    {
            //        new TimeTableGroup
            //        {
            //            GroupId = 1,
            //            TimeTableId = 1,
            //        },
            //        new TimeTableGroup
            //        {
            //            GroupId = 2,
            //            TimeTableId = 1,
            //        },
            //    });
            //}

            //await context.SaveChangesAsync();

            //if (!context.Couples.Any())
            //{
            //    await context.Couples.AddRangeAsync(new List<Couple>
            //    {
            //        new Couple
            //        {
            //            IsSubgroups = false,
            //            Subgroups = 0,
            //            DisciplineId = 8,
            //            AudienceId = 6,
            //            TimeWindowId = 1,
            //            UserId = "2d9c95e5-f5e9-4891-80d4-ee7818e7f173",
            //            TimeTableGroupId = 1
            //        },
            //        new Couple
            //        {
            //            IsSubgroups = false,
            //            Subgroups = 0,
            //            DisciplineId = 7,
            //            AudienceId = 6,
            //            TimeWindowId = 1,
            //            UserId = "6176f305-d1f7-4310-8be5-fb188e2c05c1",
            //            TimeTableGroupId = 1
            //        },
            //        new Couple
            //        {
            //            IsSubgroups = false,
            //            Subgroups = 0,
            //            DisciplineId = 9,
            //            AudienceId = 6,
            //            TimeWindowId = 1,
            //            UserId = "651507e2-6aca-4876-89e1-e03a0c1cb8e0",
            //            TimeTableGroupId = 1
            //        },
            //        new Couple
            //        {
            //            IsSubgroups = false,
            //            Subgroups = 0,
            //            DisciplineId = 10,
            //            AudienceId = 6,
            //            TimeWindowId = 1,
            //            UserId = "ab3ee0eb-fccf-4522-b41a-02ad24c4b75a",
            //            TimeTableGroupId = 1
            //        },
            //        new Couple
            //        {
            //            IsSubgroups = false,
            //            Subgroups = 0,
            //            DisciplineId = 11,
            //            AudienceId = 1,
            //            TimeWindowId = 1,
            //            UserId = "cbe0d18e-2763-4e7e-9ece-5eb8e7d08461",
            //            TimeTableGroupId = 2
            //        },
            //        new Couple
            //        {
            //            IsSubgroups = false,
            //            Subgroups = 0,
            //            DisciplineId = 13,
            //            AudienceId = 2,
            //            TimeWindowId = 1,
            //            UserId = "de1eaadb-4f45-4594-899a-66202bba02b2",
            //            TimeTableGroupId = 2
            //        },
            //        new Couple
            //        {
            //            IsSubgroups = false,
            //            Subgroups = 0,
            //            DisciplineId = 7,
            //            AudienceId = 2,
            //            TimeWindowId = 1,
            //            UserId = "651507e2-6aca-4876-89e1-e03a0c1cb8e0",
            //            TimeTableGroupId = 2
            //        },
            //        new Couple
            //        {
            //            IsSubgroups = false,
            //            Subgroups = 0,
            //            DisciplineId = 10,
            //            AudienceId = 6,
            //            TimeWindowId = 1,
            //            UserId = "ab3ee0eb-fccf-4522-b41a-02ad24c4b75a",
            //            TimeTableGroupId = 2
            //        },
            //    });
            //}


            //await context.SaveChangesAsync();
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
