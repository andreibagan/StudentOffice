using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudentOffice.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Anketa> Anketa { get; set; }
        public DbSet<Audience> Audience { get; set; }
        public DbSet<Discipline> Discipline { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Timetable> Timetable { get; set; }
        public DbSet<TimeWindow> TimeWindow { get; set; }

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
