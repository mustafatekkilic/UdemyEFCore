using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.IsolationLevels.DTO;
using UdemyEFCore.IsolationLevels.Entity;

namespace UdemyEFCore.IsolationLevels.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextInitializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            .UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));

        }
    }
}
