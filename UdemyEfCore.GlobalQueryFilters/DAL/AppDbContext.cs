using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.GlobalQueryFilters.Entity;

namespace UdemyEFCore.GlobalQueryFilters.DAL
{
    public class AppDbContext : DbContext
    {
        private readonly int Barcode;

        public AppDbContext(int barcode)
        {
            Barcode = barcode;
        }
        public AppDbContext()
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextInitializer.Build();
            //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).
                UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //QueryFilters
            //modelBuilder.Entity<Product>().Property(x => x.IsDeleted).HasDefaultValue(false);
            //modelBuilder.Entity<Product>().HasQueryFilter(x => !x.IsDeleted);

            //if (Barcode != default(int))
            //    modelBuilder.Entity<Product>().HasQueryFilter(x => x.Barcode == Barcode);


            base.OnModelCreating(modelBuilder);
        }
    }
}
