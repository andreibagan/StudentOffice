using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudentOffice.Models.DataBase
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Anketa> Anketas { get; set; }
        public DbSet<Audience> Audiences { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Couple> Couples { get; set; }
        public DbSet<TimeWindow> TimeWindows { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Spravka> Spravkas { get; set; }
        public DbSet<SpravkaOrder> SpravkaOrders { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<TypeOfSpravka> TypeOfSpravkas { get; set; }
        public DbSet<TimeTableGroup> TimeTableGroups { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<GroupDiscipline> GroupDisciplines { get; set; }
        public DbSet<GroupExam> GroupExams { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<MarkExam> MarkExams { get; set; }
        public DbSet<MarkLog> MarkLogs { get; set; }
        public DbSet<MarkUser> MarkUsers { get; set; }
        public DbSet<Omission> Omissions { get; set; }
        public DbSet<Image> Images { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //string adminRoleName = "admin";
            //string userRoleName = "user";
            //string studentRoleName = "student";
            //string teacherRoleName = "teacher";

            //string adminEmail = "admin@mail.ru";
            //string adminPassword = "12345";

            //Role adminRole = new Role { RoleId = 1, Name = adminRoleName };
            //Role userRole = new Role { RoleId = 2, Name = userRoleName };
            //Role studentRole = new Role { RoleId = 3, Name = studentRoleName };
            //Role teacherRole = new Role { RoleId = 4, Name = teacherRoleName };

            //User adminUser = new User { UserId = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.RoleId };

            //modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole, studentRole, teacherRole });
            //modelBuilder.Entity<User>().HasData(new User[] { adminUser });
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
