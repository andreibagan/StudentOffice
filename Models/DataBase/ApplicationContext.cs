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
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Spravka> Spravkas { get; set; }
        public DbSet<SpravkaOrder> SpravkaOrders { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<TypeOfSpravka> TypeOfSpravkas { get; set; }
        public DbSet<TimeTableGroup> TimeTableGroups { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<MarkExam> MarkExams { get; set; }
        public DbSet<MarkLog> MarkLogs { get; set; }
        public DbSet<MarkUser> MarkUsers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<SelectionСommittee> SelectionСommitties { get; set; }

        public DbSet<MainPlan> MainPlans { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
