using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class TaskContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=TaskContextDB; integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Email = "admin@gmail.com", Password = "1234", RoleId = 1 },
                new User { UserId = 2, Email = "analyst@gmail.com", Password = "1234", RoleId = 2 },
                new User { UserId = 3, Email = "personnel@gmail.com", Password = "1234", RoleId = 3 }
                );
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Analyst" },
                new Role { RoleId = 3, RoleName = "Personnel" }
                );
            modelBuilder.Entity<Developer>().HasData(
                new Developer { DeveloperId = 1, DeveloperName = "Burak" },
                new Developer { DeveloperId = 2, DeveloperName = "Merve" },
                new Developer { DeveloperId = 3, DeveloperName = "Furkan" },
                new Developer { DeveloperId = 4, DeveloperName = "Enes" },
                new Developer { DeveloperId = 5, DeveloperName = "Miray" },
                new Developer { DeveloperId = 6, DeveloperName = "Dilara" },
                new Developer { DeveloperId = 7, DeveloperName = "Buse" },
                new Developer { DeveloperId = 8, DeveloperName = "Alper" }
                );
            modelBuilder.Entity<DifficultyLevel>().HasData(
                new DifficultyLevel { DifficultyId = 1, DifficultyName = "Çok Çok Kolay" },
                new DifficultyLevel { DifficultyId = 2, DifficultyName = "Çok Kolay" },
                new DifficultyLevel { DifficultyId = 3, DifficultyName = "Kolay" },
                new DifficultyLevel { DifficultyId = 4, DifficultyName = "Normal Düzey" },
                new DifficultyLevel { DifficultyId = 5, DifficultyName = "Zaman Alıcı" },
                new DifficultyLevel { DifficultyId = 6, DifficultyName = "Zor" },
                new DifficultyLevel { DifficultyId = 7, DifficultyName = "Çok Zor" },
                new DifficultyLevel { DifficultyId = 8, DifficultyName = "Çok Çok Zor" }
                );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskModel> TaskModels { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
    }
}
