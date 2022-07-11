using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.AutoMapper.DTO;
using UdemyEFCore.AutoMapper.Entity;

namespace UdemyEFCore.AutoMapper.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; } //GitTest
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<ProductEssential> ProductEssentials { get; set; }
        public DbSet<ProductWithFeature> ProductWithFeatures{ get; set; }
        public DbSet<ProductFull> ProductFull { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextInitializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
