using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.MultipleDbContext.DTO;
using UdemyEFCore.MultipleDbContext.Entity;

namespace UdemyEFCore.MultipleDbContext.DAL
{
    public class AppDbContext : DbContext
    {
        private DbConnection _connection;

        public AppDbContext(DbConnection connection)
        {
            _connection = connection;
        }

        public AppDbContext()
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<ProductEssential> ProductEssentials { get; set; }
        public DbSet<ProductWithFeature> ProductWithFeatures { get; set; }
        public DbSet<ProductFull> ProductFull { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connection == default(DbConnection))
            {
                DbContextInitializer.Build();
                optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                    .UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon")); ;
            }
            else
            {
                optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .UseSqlServer(_connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
