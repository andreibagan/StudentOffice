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

            if (!context.Specializations.Any())
            {
                await context.Specializations.AddRangeAsync(new List<Specialization>
                {
                    new Specialization
                    {
                        SpecializationName = "Хозяйственно-правовая и кадровая работа",
                    },
                    new Specialization
                    {
                        SpecializationName = "Информационное обеспечение бизнеса",
                    },
                    new Specialization
                    {
                        SpecializationName = "Товароведение продовольственных и непродовольственных товаров",
                    },
                    new Specialization
                    {
                        SpecializationName = "Системное программирование",
                    },
                    new Specialization
                    {
                        SpecializationName = "Программное обеспечение обработки экономической и деловой информации",
                    },
                    new Specialization
                    {
                        SpecializationName = "Операционная деятельность в логистике",
                    },
                    new Specialization
                    {
                        SpecializationName = "Бухгалтерский учет, анализ и контроль",
                    },
                    new Specialization
                    {
                        SpecializationName = "Визуальный мерчендайзинг",
                    },
                });
            }

            if (!context.Groups.Any())
            {
                await context.Groups.AddRangeAsync(new List<Group>
                {
                    new Group
                    {
                        GroupName = "П1",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 1,

                    },
                    new Group
                    {
                        GroupName = "Б1",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 1,
                    },
                    new Group
                    {
                        GroupName = "П2",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 2,
                    },
                    new Group
                    {
                        GroupName = "Б2",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 2,
                    },
                    new Group
                    {
                        GroupName = "Б3",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 3,
                    },
                    new Group
                    {
                        GroupName = "К3",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 3,
                    },
                    new Group
                    {
                        GroupName = "П3",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 3,
                    },
                    new Group
                    {
                        GroupName = "П310",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 3,
                    },
                    new Group
                    {
                        GroupName = "ПО209",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 2,
                    },
                    new Group
                    {
                        GroupName = "Б301",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 3,
                    },
                    new Group
                    {
                        GroupName = "П206",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 2,
                    },
                    new Group
                    {
                        GroupName = "СП405",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 4,
                    },

                    new Group
                    {
                        GroupName = "СП105",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 1,
                    },
                    new Group
                    {
                        GroupName = "ОД103",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 1,
                    },
                    new Group
                    {
                        GroupName = "ОД303",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 3,
                    },
                    new Group
                    {
                        GroupName = "ПО309",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 3,
                    },
                    new Group
                    {
                        GroupName = "П306",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 3,
                    },
                    new Group
                    {
                        GroupName = "Б101",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 1,
                    },
                    new Group
                    {
                        GroupName = "СП305",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 3,
                    },
                    new Group
                    {
                        GroupName = "ВМ201",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 2,
                    },
                    new Group
                    {
                        GroupName = "И312",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 3,
                    },
                    new Group
                    {
                        GroupName = "СП205",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 2,
                    },
                    new Group
                    {
                        GroupName = "ОД203",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 2,
                    },
                    new Group
                    {
                        GroupName = "П106",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 1,
                    },
                    new Group
                    {
                        GroupName = "П210",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 2,
                    },
                    new Group
                    {
                        GroupName = "ПО409",
                        YearOfFormation = new DateTime(2020, 09, 01),
                        ExpirationDate = new DateTime(2023, 06, 23),
                        Course = 4,
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
                        AudienceName = "10",
                        AudienceNameShort = "10",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "11",
                        AudienceNameShort = "11",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "12",
                        AudienceNameShort = "12",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "13",
                        AudienceNameShort = "13",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "14",
                        AudienceNameShort = "14",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "15",
                        AudienceNameShort = "15",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "16",
                        AudienceNameShort = "16",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "21",
                        AudienceNameShort = "21",
                        AudienceType = AudienceType.Cabinet

                    },
                    new Audience
                    {
                        AudienceName = "22",
                        AudienceNameShort = "22",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "24",
                        AudienceNameShort = "24",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "23",
                        AudienceNameShort = "23",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "25",
                        AudienceNameShort = "25",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "26",
                        AudienceNameShort = "26",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "27",
                        AudienceNameShort = "27",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "29",
                        AudienceNameShort = "29",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "30",
                        AudienceNameShort = "30",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "31",
                        AudienceNameShort = "31",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "32",
                        AudienceNameShort = "32",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "15",
                        AudienceNameShort = "15",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "33",
                        AudienceNameShort = "33",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "35",
                        AudienceNameShort = "35",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "36",
                        AudienceNameShort = "36",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "37",
                        AudienceNameShort = "37",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "38",
                        AudienceNameShort = "38",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "40",
                        AudienceNameShort = "40",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "41",
                        AudienceNameShort = "41",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "42",
                        AudienceNameShort = "42",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "43",
                        AudienceNameShort = "43",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "44",
                        AudienceNameShort = "44",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "Библиотека",
                        AudienceNameShort = "Библ",
                        AudienceType = AudienceType.Library
                    },
                    new Audience
                    {
                        AudienceName = "Комната отдыха",
                        AudienceNameShort = "КО",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "Читальный зал",
                        AudienceNameShort = "ЧЗ",
                        AudienceType = AudienceType.Cabinet
                    },
                    new Audience
                    {
                        AudienceName = "Спортзал",
                        AudienceNameShort = "С/зал",
                        AudienceType = AudienceType.Gym
                    },
                    new Audience
                    {
                        AudienceName = "Спортзал2",
                        AudienceNameShort = "С/зал2",
                        AudienceType = AudienceType.Gym
                    },
                });
            }

            if (!context.Disciplines.Any())
            {
                await context.Disciplines.AddRangeAsync(new List<Discipline>
                {
                    new Discipline
                    {
                        DisciplineName = "1С Программирование",
                        DisciplineShortName = "1Сп"
                    },
                    new Discipline
                    {
                        DisciplineName = "Автоматизация управленческой деятельности организации",
                        DisciplineShortName = "АУДО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Автоматизация учета",
                        DisciplineShortName = "АУ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Автоматизированная обработка учёной информации",
                        DisciplineShortName = "АОУИ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Административно-деликтное и процессуально-исполнительное право",
                        DisciplineShortName = "АДиПИП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Административное право",
                        DisciplineShortName = "АП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Активные формы продвижения товаров на рынке",
                        DisciplineShortName = "АФПТ на р"
                    },
                    new Discipline
                    {
                        DisciplineName = "Актуальные проблемы гражданского права",
                        DisciplineShortName = "АПГП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Анализ хозяйственной деятельности",
                        DisciplineShortName = "АХД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Арифметико-логические основы  вычислительной техники",
                        DisciplineShortName = "АЛОВТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Астрономия",
                        DisciplineShortName = "Астро"
                    },
                    new Discipline
                    {
                        DisciplineName = "Базы данных и системы управления базами данных",
                        DisciplineShortName = "БДиСУБД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Белорусская литература",
                        DisciplineShortName = "БЛ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Белорусский язык",
                        DisciplineShortName = "БЯ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Белорусский язык (профессиональная лексика)",
                        DisciplineShortName = "БЯпроф"
                    },
                    new Discipline
                    {
                        DisciplineName = "Бизнес-планирование",
                        DisciplineShortName = "БП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Биология",
                        DisciplineShortName = "Био"
                    },
                    new Discipline
                    {
                        DisciplineName = "Бухгалтерский учет",
                        DisciplineShortName = "БУ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Бухгалтерский учет в отрослях потребительской кооперации",
                        DisciplineShortName = "БУвОПК"
                    },
                    new Discipline
                    {
                        DisciplineName = "Бухгалтерский учет в торговле",
                        DisciplineShortName = "БУВТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Введение в специальность",
                        DisciplineShortName = "ВвС"
                    },
                    new Discipline
                    {
                        DisciplineName = "Введение в специальность (Факультатив)",
                        DisciplineShortName = "В в С"
                    },
                    new Discipline
                    {
                        DisciplineName = "Великая отечественная война советского народа",
                        DisciplineShortName = "ВОВ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Внешнеэкономическая деятельность",
                        DisciplineShortName = "ВД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Возможности языка Java в сетевом программировании",
                        DisciplineShortName = "JAVA"
                    },
                    new Discipline
                    {
                        DisciplineName = "Техника коммуникации и основы командообразования",
                        DisciplineShortName = "ТКиОК"
                    },
                    new Discipline
                    {
                        DisciplineName = "Воспитательный час",
                        DisciplineShortName = "Воспит. ч."
                    },
                    new Discipline
                    {
                        DisciplineName = "Всемирная история",
                        DisciplineShortName = "ВИ"
                    },
                    new Discipline
                    {
                        DisciplineName = "География",
                        DisciplineShortName = "Гео"
                    },
                    new Discipline
                    {
                        DisciplineName = "Государственный экзамен по специальности",
                        DisciplineShortName = "ГЭК"
                    },
                    new Discipline
                    {
                        DisciplineName = "Гражданский процесс",
                        DisciplineShortName = "ГПр"
                    },
                    new Discipline
                    {
                        DisciplineName = "Гражданское право",
                        DisciplineShortName = "ГП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Деловая документация",
                        DisciplineShortName = "Дел.Док."
                    },
                    new Discipline
                    {
                        DisciplineName = "Дипломное проектирование",
                        DisciplineShortName = "Дипл. пр."
                    },
                    new Discipline
                    {
                        DisciplineName = "Документацинное обеспечение логистических процессов",
                        DisciplineShortName = "ДОЛП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Документационное обеспечение  управления",
                        DisciplineShortName = "ДОУ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Документационное обеспечение управления и деловая документация организации",
                        DisciplineShortName = "ДОУиДДП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Допризывная (медицинская) подготовка",
                        DisciplineShortName = "ДМ и МП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Жилищное право",
                        DisciplineShortName = "ЖП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Закупочная и производственная логистика",
                        DisciplineShortName = "ЗиПЛ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Защита дипломного проекта",
                        DisciplineShortName = "ЗДП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Защита компьютерной информации",
                        DisciplineShortName = "ЗКИ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Защита населения и территории от чрезвычайных ситуаций",
                        DisciplineShortName = "ЗН"
                    },
                    new Discipline
                    {
                        DisciplineName = "Земельное право",
                        DisciplineShortName = "ЗП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Иностранный язык",
                        DisciplineShortName = "ИЯ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Иностранный язык в профессии",
                        DisciplineShortName = "Ин яз в пр"
                    },
                    new Discipline
                    {
                        DisciplineName = "Иностранный язык делового общения",
                        DisciplineShortName = "ИЯДО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Инструментальное программное обеспечение",
                        DisciplineShortName = "инстр. по."
                    },
                    new Discipline
                    {
                        DisciplineName = "Информатика",
                        DisciplineShortName = "Инфо"
                    },
                    new Discipline
                    {
                        DisciplineName = "Информационные технологии",
                        DisciplineShortName = "ИТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Информационные технологии в пофессиональной деятельности",
                        DisciplineShortName = "ИТ в ПрофД"
                    },
                    new Discipline
                    {
                        DisciplineName = "История Беларуси",
                        DisciplineShortName = "ИБ"
                    },
                    new Discipline
                    {
                        DisciplineName = "История государства и права",
                        DisciplineShortName = "Игп"
                    },
                    new Discipline
                    {
                        DisciplineName = "История государства и права Беларуси",
                        DisciplineShortName = "ИГиПБ"
                    },
                    new Discipline
                    {
                        DisciplineName = "История стилей в искусстве",
                        DisciplineShortName = "ИСвИ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Квалификационный экзамен",
                        DisciplineShortName = "Квалиф.экз"
                    },
                    new Discipline
                    {
                        DisciplineName = "Коммерческая деятельность",
                        DisciplineShortName = "КД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Компьютерная графика",
                        DisciplineShortName = "КГ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Компьютерная лексика (факультативный курс)",
                        DisciplineShortName = "КЛ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Компьютерная лингвистика",
                        DisciplineShortName = "КЛ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Компьютерные сети",
                        DisciplineShortName = "КС"
                    },
                    new Discipline
                    {
                        DisciplineName = "Конституционное право",
                        DisciplineShortName = "КП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Конструирование программ и языки программирования",
                        DisciplineShortName = "КПиАП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Конфигурирование и адаптация программных средств для систем управления",
                        DisciplineShortName = "КиАПСУ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Коррупция и её общественная опасность",
                        DisciplineShortName = "Коррупция"
                    },
                    new Discipline
                    {
                        DisciplineName = "Коррупция и ее общественная опасность (факультативный курс)",
                        DisciplineShortName = "КиООфа"
                    },
                    new Discipline
                    {
                        DisciplineName = "Культура речи юриста",
                        DisciplineShortName = "КРЮ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Культурное наследие белорусов",
                        DisciplineShortName = "КНБ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Культурное наследие белорусов (факультативный курс)",
                        DisciplineShortName = "ТКиОК"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовая работа  по организация и технология торговли",
                        DisciplineShortName = "ОиТТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовая работа по организации производства",
                        DisciplineShortName = "КР по ОП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовая работа по автоматизации управленческой деятельности",
                        DisciplineShortName = "КР по АУД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовая работа по базам данных и системам  управления базами данных",
                        DisciplineShortName = "КР по БД и"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовая работа по бухгалтерскому учёту",
                        DisciplineShortName = "КР по БУ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовая работа по коммерческой деятельности",
                        DisciplineShortName = "КР по КД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовая работа по конструированию программ  и языкам программирования",
                        DisciplineShortName = "КР по КПИЯ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовая работа по основам  алгоритмизации и програмированию",
                        DisciplineShortName = "КР по ОАП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовая работа по экономике организации",
                        DisciplineShortName = "КР по ЭО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовое проектирование по автоматизации",
                        DisciplineShortName = "Курс.проек"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовое проектирование по базам данных и СУБД",
                        DisciplineShortName = "Курс.проек"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовое проектирование по бухгалтерскому учету",
                        DisciplineShortName = "КПБУ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовое проектирование по коммерческой деятельности",
                        DisciplineShortName = "Курс.проек"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовое проектирование по оранизации производства",
                        DisciplineShortName = "КППОП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Курсовое проектирование по организации и технологии торговли",
                        DisciplineShortName = "КПОТТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Логистика",
                        DisciplineShortName = "Логистика"
                    },
                    new Discipline
                    {
                        DisciplineName = "Логистика складирования",
                        DisciplineShortName = "Лскад"
                    },
                    new Discipline
                    {
                        DisciplineName = "Маркетинг",
                        DisciplineShortName = "Маркетинг"
                    },
                    new Discipline
                    {
                        DisciplineName = "Математика",
                        DisciplineShortName = "Математика"
                    },
                    new Discipline
                    {
                        DisciplineName = "Математика (ч.1)",
                        DisciplineShortName = "Математика (ч.1)"
                    },
                    new Discipline
                    {
                        DisciplineName = "Математика(ч.2)",
                        DisciplineShortName = "Математика(ч.2)"
                    },
                    new Discipline
                    {
                        DisciplineName = "Математическое моделирование",
                        DisciplineShortName = "МатМод"
                    },
                    new Discipline
                    {
                        DisciplineName = "Международное право",
                        DisciplineShortName = "МП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Международное публичное право",
                        DisciplineShortName = "МПП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Международные стандарты бухгалтерского (финансового) учета ",
                        DisciplineShortName = "МСБУ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Международные стандарты бухгалтерской (финансовой) отчётности",
                        DisciplineShortName = "Междун ста"
                    },
                    new Discipline
                    {
                        DisciplineName = "Методы и алгоритмы принятия решений",
                        DisciplineShortName = "МАПР"
                    },
                    new Discipline
                    {
                        DisciplineName = "Микропроцессорная техника",
                        DisciplineShortName = "МТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Налоговое право",
                        DisciplineShortName = "НП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Налогообложение",
                        DisciplineShortName = "Налог."
                    },
                    new Discipline
                    {
                        DisciplineName = "Нормоконтроль",
                        DisciplineShortName = "Норм"
                    },
                    new Discipline
                    {
                        DisciplineName = "Оборудование хранилищ и устройств для погрузочно-разгрузочных работ",
                        DisciplineShortName = "ОХ и УПРР"
                    },
                    new Discipline
                    {
                        DisciplineName = "Общая теория права",
                        DisciplineShortName = "ОТП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Обществоведение",
                        DisciplineShortName = "Общество"
                    },
                    new Discipline
                    {
                        DisciplineName = "Объектно-ориентированное программирование",
                        DisciplineShortName = "ООП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Операционные системы",
                        DisciplineShortName = "ОС"
                    },
                    new Discipline
                    {
                        DisciplineName = "Организация заготовок сельскохозяйственной продукции и сырья",
                        DisciplineShortName = "ОЗСПИС"
                    },
                    new Discipline
                    {
                        DisciplineName = "Организация заготовок сельскохозяйственной промышленности ",
                        DisciplineShortName = "ОЗСХП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Организация и технология торговли",
                        DisciplineShortName = "ОТТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Организация и функционирование ЭВМ",
                        DisciplineShortName = "ОФЭВМ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Организация производства",
                        DisciplineShortName = "ОП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Организация работы кадровой службы в организации",
                        DisciplineShortName = "ОРКС"
                    },
                    new Discipline
                    {
                        DisciplineName = "Организация торговли",
                        DisciplineShortName = "ОТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Организация ЭВМ и систем",
                        DisciplineShortName = "ОЭВМи сист"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы алгоритмизации и программирование",
                        DisciplineShortName = "ОАП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы безопасной организации  труда программиста(факультативный курс",
                        DisciplineShortName = "ОБОТПф"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы безопасной организации труда программиста",
                        DisciplineShortName = "ОБОТП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы гендерной культуры",
                        DisciplineShortName = "ОГК"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы здорового и рационального питания",
                        DisciplineShortName = "ОЗиРП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы идеологии белорусского государства",
                        DisciplineShortName = "Осн.идеоло"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы инженерной графики",
                        DisciplineShortName = "ОИГ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы конфликтологии",
                        DisciplineShortName = "ОК"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы конфликтологии(факультативный курс)",
                        DisciplineShortName = "ОКф"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы кооперативного движения",
                        DisciplineShortName = "ОКД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы маркетинга",
                        DisciplineShortName = "ОМ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы менеджмента",
                        DisciplineShortName = "ОМ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы мерчендайзинга",
                        DisciplineShortName = "ОМ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы мерчендайзинга (факультативный курс)",
                        DisciplineShortName = "ОМ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы организации торговли",
                        DisciplineShortName = "ООТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы организации торговли(факультативный курс)",
                        DisciplineShortName = "ООТф"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы охраны труда",
                        DisciplineShortName = "ООТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы права",
                        DisciplineShortName = "ОП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы предпринимательской деятельности",
                        DisciplineShortName = "Осн.предпр"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы предпринимательской деятельности и управление проектами",
                        DisciplineShortName = "ОПДиУП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы предпринимательства",
                        DisciplineShortName = "ОП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы семейной жизни",
                        DisciplineShortName = "ОСЖ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы социально-гуманитарных наук",
                        DisciplineShortName = "ОСГН"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы социологии и политологии",
                        DisciplineShortName = "ОСИП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы статистической обработки информации",
                        DisciplineShortName = "ОСОИ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы технического нормирования и стандартизации",
                        DisciplineShortName = "ОТНС"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы товароведения",
                        DisciplineShortName = "ОТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы управления интеллектуальной собственностью",
                        DisciplineShortName = "ОУИС"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы философии",
                        DisciplineShortName = "ОФ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы финансового права",
                        DisciplineShortName = "ОФП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы цифровой экономики",
                        DisciplineShortName = "ОЦЭ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы экономики",
                        DisciplineShortName = "ОЭ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы экономической теории",
                        DisciplineShortName = "ОЭТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Основы языков программирования",
                        DisciplineShortName = "ОЯП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Особенности организации труда юриста",
                        DisciplineShortName = "ООТЮ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Особенности учета индивидуальных предпринимателей",
                        DisciplineShortName = "ОЧИП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Офисное программирование",
                        DisciplineShortName = "Офисное пр"
                    },
                    new Discipline
                    {
                        DisciplineName = "Оформление кадровой документации",
                        DisciplineShortName = "ОКД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Охрана окружающей среды и энергосбережение",
                        DisciplineShortName = "ООСЭ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Охрана труда",
                        DisciplineShortName = "ОТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Порядок оформления документов для назначения пенсий",
                        DisciplineShortName = "ПОДдНП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Правила дорожного движения",
                        DisciplineShortName = "ПДД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Право социального обеспечения",
                        DisciplineShortName = "ПСО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Правовое обеспечение",
                        DisciplineShortName = "прав.обесп"
                    },
                    new Discipline
                    {
                        DisciplineName = "Правовое обеспечение коммерческой деятельности",
                        DisciplineShortName = "ПОКД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Правовое регулирование предпринимательской деятельности",
                        DisciplineShortName = "ПРПД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Преддипломная практика",
                        DisciplineShortName = "ПП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Прикладая информатика",
                        DisciplineShortName = "ПИ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Прикладное программное обеспечение",
                        DisciplineShortName = "ППО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Проверка дипломных проектов",
                        DisciplineShortName = "пров.дипл"
                    },
                    new Discipline
                    {
                        DisciplineName = "Проверка и контроль",
                        DisciplineShortName = "ПиК"
                    },
                    new Discipline
                    {
                        DisciplineName = "Проверка практики",
                        DisciplineShortName = "пров.практ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Программные средства создания Internet – приложений",
                        DisciplineShortName = "ПССИП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Производственное обучение",
                        DisciplineShortName = "ПО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Психологические аспекты эффективного делового общения",
                        DisciplineShortName = "Псих асп.д"
                    },
                    new Discipline
                    {
                        DisciplineName = "Психология и этика деловых отношений",
                        DisciplineShortName = "ПЭДО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Разработка Windows-приложений средствами WinAPI",
                        DisciplineShortName = "РПСW"
                    },
                    new Discipline
                    {
                        DisciplineName = "Разработки приложений для мобильных устройств",
                        DisciplineShortName = "РПдМУ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Распределительная логистика",
                        DisciplineShortName = "РЛ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Ревизия и контроль",
                        DisciplineShortName = "РК"
                    },
                    new Discipline
                    {
                        DisciplineName = "Рецензирование дипломных проектов",
                        DisciplineShortName = "рец.дип"
                    },
                    new Discipline
                    {
                        DisciplineName = "Руководство практикой",
                        DisciplineShortName = "рук.практ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Русская литература",
                        DisciplineShortName = "РЯ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Русский язык",
                        DisciplineShortName = "РЯ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Семейное право",
                        DisciplineShortName = "СП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Сетевые операционные системы и сетевая безопасность",
                        DisciplineShortName = "СОС и СБ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Система управления охраной труда в организации",
                        DisciplineShortName = "Суот"
                    },
                    new Discipline
                    {
                        DisciplineName = "Система управления охраной труда в организации (факультативный курс)",
                        DisciplineShortName = "СУОТвО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Системное программирование",
                        DisciplineShortName = "СП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Системное программное обеспечение",
                        DisciplineShortName = "СПО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Системы управления базами данных",
                        DisciplineShortName = "СУБД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Современные компьютерные офисные технологии",
                        DisciplineShortName = "СКОТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Современные системы программирования",
                        DisciplineShortName = "ССП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Социальное и медицинское право",
                        DisciplineShortName = "СиМП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Способы обработки учетной информации с применением ПЭВМ",
                        DisciplineShortName = "СОУИ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Стандартизация и сертификация",
                        DisciplineShortName = "СиС"
                    },
                    new Discipline
                    {
                        DisciplineName = "Стандартизация и сертификация программного обеспечения",
                        DisciplineShortName = "СИСПО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Статистика",
                        DisciplineShortName = "Стасист."
                    },
                    new Discipline
                    {
                        DisciplineName = "Структуры и алгоритмы обработки данных ",
                        DisciplineShortName = "САОД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Судебная практика по трудовым делам",
                        DisciplineShortName = "СППТД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Судоустройство",
                        DisciplineShortName = "С"
                    },
                    new Discipline
                    {
                        DisciplineName = "Таможенное право",
                        DisciplineShortName = "ТП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Теоретические основы товароведения",
                        DisciplineShortName = "ТОТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Теория бухгалтерского учета",
                        DisciplineShortName = "ТБУ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Теория вероятностей и математическая статистика",
                        DisciplineShortName = "ТВиМС"
                    },
                    new Discipline
                    {
                        DisciplineName = "Тестирование и отладка программного обеспечения ",
                        DisciplineShortName = "ТиОПБ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Тестирование программного обеспечения",
                        DisciplineShortName = "ТПО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Техника коммуникации и основы командообразования",
                        DisciplineShortName = "ТКиОК"
                    },
                    new Discipline
                    {
                        DisciplineName = "Технологическая практика",
                        DisciplineShortName = "ТП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Технология разработки информационного обеспечения",
                        DisciplineShortName = "ТРИО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Технология разработки программного обеспечения",
                        DisciplineShortName = "ТРПО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Товароведение",
                        DisciplineShortName = "Товаровеен"
                    },
                    new Discipline
                    {
                        DisciplineName = "Товароведение непродовольственных товаров",
                        DisciplineShortName = "ТНТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Товароведение продовольственных товаров",
                        DisciplineShortName = "ТПТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Торговое оборудование",
                        DisciplineShortName = "ТО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Торговые вычисления",
                        DisciplineShortName = "ТВ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Транспортная логистика",
                        DisciplineShortName = "ТЛ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Трудовое право",
                        DisciplineShortName = "ТП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Трудовое право и право социального обеспечения",
                        DisciplineShortName = "ТПиПСО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Уголовное право",
                        DisciplineShortName = "УП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Уголовный процесс",
                        DisciplineShortName = "УП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Упрвление зпасами в логистике",
                        DisciplineShortName = "УЗ в Л"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика для получения профессии рабочего",
                        DisciplineShortName = "УПППР"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика по автоматизации учета",
                        DisciplineShortName = "УПАУ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика по бухгалтерскому учету",
                        DisciplineShortName = "УПБУ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика по информационным технологиям",
                        DisciplineShortName = "УПИТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика по коммерческой деятельности",
                        DisciplineShortName = "УПКД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика по логистике",
                        DisciplineShortName = "уп по логи"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика по налогооблажению",
                        DisciplineShortName = "УП Налог."
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика по программированию",
                        DisciplineShortName = "УП по прог"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика по разработке и сопровождению программного обеспечения",
                        DisciplineShortName = "УПпоСПО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика по системному программному обеспечению",
                        DisciplineShortName = "УП по СПО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика по технологии разработки программного обеспечения",
                        DisciplineShortName = "УП по ТРПО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика по учёту и отчётности",
                        DisciplineShortName = "УП по учет"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика по экономике организации",
                        DisciplineShortName = "УПЭО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учебная практика по юридической деятельности",
                        DisciplineShortName = "УПЮД"
                    },
                    new Discipline
                    {
                        DisciplineName = "Учёт и отчётнось",
                        DisciplineShortName = "уч и отч"
                    },
                    new Discipline
                    {
                        DisciplineName = "Факультатив 'Автоматизированная обработка учетной информации'",
                        DisciplineShortName = "аоуи"
                    },
                    new Discipline
                    {
                        DisciplineName = "Факультативные занятия по Физической культуре и здоровью",
                        DisciplineShortName = "ФКЗ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Физика",
                        DisciplineShortName = "Физ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Физическая культура и здоровье",
                        DisciplineShortName = "ФКиЗ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Финансовое право",
                        DisciplineShortName = "ФП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Финансы и кредит",
                        DisciplineShortName = "ФК"
                    },
                    new Discipline
                    {
                        DisciplineName = "Финансы организации",
                        DisciplineShortName = "ФО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Формирование предпринимательского образа мышления",
                        DisciplineShortName = "ФПОМ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Формирование семейных ценностей",
                        DisciplineShortName = "ФСЦ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Функциональная стилистика русского языка",
                        DisciplineShortName = "ФСРЯ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Химия",
                        DisciplineShortName = "Хим"
                    },
                    new Discipline
                    {
                        DisciplineName = "Хозяйственное право",
                        DisciplineShortName = "ХП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Хозяйственный процесс",
                        DisciplineShortName = "ХП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Ценообразование",
                        DisciplineShortName = "ЦО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Человек в современном мире",
                        DisciplineShortName = "ЧвСМ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Черчение",
                        DisciplineShortName = "Черчение"
                    },
                    new Discipline
                    {
                        DisciplineName = "Экологическое право",
                        DisciplineShortName = "ЭП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Экономика и организация производства",
                        DisciplineShortName = "ЭИОП"
                    },
                    new Discipline
                    {
                        DisciplineName = "Экономика организации",
                        DisciplineShortName = "ЭО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Экономика торговли",
                        DisciplineShortName = "ЭТ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Этика деловых отношений",
                        DisciplineShortName = "ЭДО"
                    },
                    new Discipline
                    {
                        DisciplineName = "Этика и психология профессиональной деятельности юриста",
                        DisciplineShortName = "ЭиППДЮ"
                    },
                    new Discipline
                    {
                        DisciplineName = "Юридическая служба в организации",
                        DisciplineShortName = "ЮСВО"
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

            //if (!context.SelectionСommitties.Any())
            //{
            //    await context.SelectionСommitties.AddRangeAsync(new List<SelectionСommittee>
            //    {
            //        new SelectionСommittee
            //        {
            //            Name = "Приемная комиссия",
            //            Year = 2021
            //        },
            //    });
            //}

            await context.SaveChangesAsync();

            if (!context.Specialties.Any())
            {
                await context.Specialties.AddRangeAsync(new List<Specialty>
                {
                    new Specialty
                    {
                        Name = "Правоведение",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Correspondence,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "П1").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Хозяйственно-правовая и кадровая работа").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Бухгалтерский учёт, анализ и контроль",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Correspondence,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "Б1").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Бухгалтерский учет, анализ и контроль").SpecializationId

                    },
                    new Specialty
                    {
                        Name = "Правоведение",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Correspondence,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "П2").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Хозяйственно-правовая и кадровая работа").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Бухгалтерский учёт, анализ и контроль",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Correspondence,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "Б2").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Бухгалтерский учет, анализ и контроль").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Бухгалтерский учёт, анализ и контроль",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Correspondence,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "Б3").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Бухгалтерский учет, анализ и контроль").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Коммерческая деятельность",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Correspondence,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "К3").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Товароведение продовольственных и непродовольственных товаров").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Правоведение",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Correspondence,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "П3").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Хозяйственно-правовая и кадровая работа").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Правоведение",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "П310").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Хозяйственно-правовая и кадровая работа").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Программное обеспечение информационных технологий",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "ПО209").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Программное обеспечение обработки экономической и деловой информации").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Бухгалтерский учёт, анализ и контроль",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "Б301").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Бухгалтерский учет, анализ и контроль").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Правоведение",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "П206").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Хозяйственно-правовая и кадровая работа").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Программное обеспечение информационных технологий",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "СП405").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Системное программирование").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Программное обеспечение информационных технологий",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "СП105").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Системное программирование").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Операционная деятельность в логистике",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "ОД103").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Операционная деятельность в логистике").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Операционная деятельность в логистике",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "ОД303").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Операционная деятельность в логистике").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Программное обеспечение информационных технологий",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "ПО309").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Программное обеспечение обработки экономической и деловой информации").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Правоведение",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "П306").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Хозяйственно-правовая и кадровая работа").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Бухгалтерский учёт, анализ и контроль",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "Б101").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Бухгалтерский учет, анализ и контроль").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Программное обеспечение информационных технологий",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "СП305").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Системное программирование").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Визуальный мерчендайзинг",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "ВМ201").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Визуальный мерчендайзинг").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Коммерческая деятельность",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "И312").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Информационное обеспечение бизнеса").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Коммерческая деятельность",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "И312").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Товароведение продовольственных и непродовольственных товаров").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Коммерческая деятельность",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "И312").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Информационное обеспечение бизнеса").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Программное обеспечение информационных технологий",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "СП205").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Системное программирование").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Операционная деятельность в логистике",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "ОД203").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Операционная деятельность в логистике").SpecializationId    
                    },
                    new Specialty
                    {
                        Name = "Правоведение",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "П106").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Хозяйственно-правовая и кадровая работа").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Правоведение",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "П210").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Хозяйственно-правовая и кадровая работа").SpecializationId
                    },
                    new Specialty
                    {
                        Name = "Программное обеспечение информационных технологий",
                        EducationType = EducationType.CCO,
                        Branch = Branch.Daytime,
                        GroupId = context.Groups.FirstOrDefault(i => i.GroupName == "ПО409").GroupId,
                        SpecializationId = context.Specializations.FirstOrDefault(i => i.SpecializationName == "Программное обеспечение обработки экономической и деловой информации").SpecializationId
                    },
                });
            }


            await context.SaveChangesAsync();

            //if (!context.MarkLogs.Any())
            //{
            //    await context.MarkLogs.AddRangeAsync(new List<MarkLog>
            //    {
            //       new MarkLog
            //       {
            //           SemesterId = 1,
            //       },
            //    });
            //}

            //await context.SaveChangesAsync();

            //if (!context.MarkUsers.Any())
            //{
            //    await context.MarkUsers.AddRangeAsync(new List<MarkUser>
            //    {
            //       new MarkUser
            //       {
            //           UserId = "4ac1a332-7bc9-4592-a955-8128cac4b874",
            //           OmissionId = 1,
            //           MarkLogId = 1
            //       },
            //       new MarkUser
            //       {
            //           UserId = "1d8820a0-6ac9-4bd2-b95c-917d6616751b",
            //           OmissionId = 2,
            //           MarkLogId = 1
            //       },
            //    });
            //}


            //await context.SaveChangesAsync();

            //if (!context.Marks.Any())
            //{
            //    await context.Marks.AddRangeAsync(new List<Mark>
            //    {
            //       new Mark
            //       {
            //           MarkUserId = 1,
            //           GroupDisciplineId = 1,
            //           MarkValue = "5"
            //       },
            //       new Mark
            //       {
            //           MarkUserId = 1,
            //           GroupDisciplineId = 2,
            //           MarkValue = "7"
            //       },
            //       new Mark
            //       {
            //           MarkUserId = 1,
            //           GroupDisciplineId = 3,
            //           MarkValue = "6"
            //       },
            //       new Mark
            //       {
            //           MarkUserId = 1,
            //           GroupDisciplineId = 4,
            //           MarkValue = "8"
            //       },
            //       new Mark
            //       {
            //           MarkUserId = 1,
            //           GroupDisciplineId = 5,
            //           MarkValue = "2"
            //       },
            //       new Mark
            //       {
            //           MarkUserId = 1,
            //           GroupDisciplineId = 6,
            //           MarkValue = "8"
            //       },
            //       new Mark
            //       {
            //           MarkUserId = 1,
            //           GroupDisciplineId = 7,
            //           MarkValue = "5"
            //       },
            //       new Mark
            //       {
            //           MarkUserId = 2,
            //           GroupDisciplineId = 1,
            //           MarkValue = "3"
            //       },
            //       new Mark
            //       {
            //           MarkUserId = 2,
            //           GroupDisciplineId = 2,
            //           MarkValue = "7"
            //       },
            //       new Mark
            //       {
            //           MarkUserId = 2,
            //           GroupDisciplineId = 3,
            //           MarkValue = "9"
            //       },
            //       new Mark
            //       {
            //           MarkUserId = 2,
            //           GroupDisciplineId = 4,
            //           MarkValue = "5"
            //       },
            //       new Mark
            //       {
            //           MarkUserId = 2,
            //           GroupDisciplineId = 5,
            //           MarkValue = "4"
            //       },
            //       new Mark
            //       {
            //           MarkUserId = 2,
            //           GroupDisciplineId = 6,
            //           MarkValue = "4"
            //       },
            //       new Mark
            //       {
            //           MarkUserId = 2,
            //           GroupDisciplineId = 7,
            //           MarkValue = "6"
            //       },
            //    });
            //}

            //if (!context.MarkExams.Any())
            //{
            //    await context.MarkExams.AddRangeAsync(new List<MarkExam>
            //    {
            //       new MarkExam
            //       {
            //           MarkValue = 7,
            //           MarkUserId = 1,
            //           GroupExamId = 1
            //       },
            //       new MarkExam
            //       {
            //           MarkValue = 5,
            //           MarkUserId = 1,
            //           GroupExamId = 2
            //       },
            //       new MarkExam
            //       {
            //           MarkValue = 8,
            //           MarkUserId = 2,
            //           GroupExamId = 1
            //       },
            //       new MarkExam
            //       {
            //           MarkValue = 9,
            //           MarkUserId = 2,
            //           GroupExamId = 2
            //       },
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

        }
    }
}
