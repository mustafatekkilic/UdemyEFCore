using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.Queries.DTO;
using UdemyEFCore.Queries.Entity;

namespace UdemyEFCore.Queries.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<ProductEssential> ProductEssentials { get; set; }
        public DbSet<ProductWithFeature> ProductWithFeatures{ get; set; }
        public DbSet<ProductFull> ProductFull { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextInitializer.Build();
            optionsBuilder.LogTo(Console.WriteLine,Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductEssential>().HasNoKey();
            //modelBuilder.Entity<ProductEssential>().HasNoKey().ToSqlQuery("select Id,Name,Price from product");
            modelBuilder.Entity<ProductWithFeature>().HasNoKey();

            modelBuilder.Entity<ProductFull>().ToView("productWithFeatures");

            base.OnModelCreating(modelBuilder);
        }
    }
}
