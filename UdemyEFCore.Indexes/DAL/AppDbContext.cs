using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.Indexes.Entity;

namespace UdemyEFCore.Indexes.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        //public DbSet<Category> Category { get; set; }
        //public DbSet<ProductFeatures> ProductFeatures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextInitializer.Build();
            optionsBuilder.UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //_context.Product.Where(x => x.Name == "kalem1").Select(x => new
            //{
            //    x.Price,
            //    x.Stock,
            //    x.Barcode
            //});

            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IncludeProperties(x => new
            {
                x.Price,
                x.Stock,
                x.Barcode
            });

            modelBuilder.Entity<Product>().HasCheckConstraint("PriceDiscountCheck", "[Price]>[DiscountPrice]");

            base.OnModelCreating(modelBuilder);
        }
    }
}
