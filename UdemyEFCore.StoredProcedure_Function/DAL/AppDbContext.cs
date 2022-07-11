using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.StoredProcedure_Function.DTO;
using UdemyEFCore.StoredProcedure_Function.Entity;

namespace UdemyEFCore.StoredProcedure_Function.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<ProductFull> ProductFull { get; set; }
        public DbSet<ProductWithFeatures> ProductWithFeatures { get; set; }

        public IQueryable<ProductWithFeatures> GetProductWithFeatures(int categoryId) => FromExpression(() => GetProductWithFeatures(categoryId));

        public int GetProductCount(int categoryId)
        {
            throw new Exception("hatahatahata");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextInitializer.Build();
            //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).
                UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Stored Procedure
            //modelBuilder.Entity<ProductFull>().HasNoKey();

            modelBuilder.Entity<ProductFull>().ToFunction("fc_product_full");
            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetProductWithFeatures), new[] { typeof(int) })!).HasName("fc_productFeatures_full_with_params");
            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetProductCount), new[] { typeof(int) })!).HasName("fc_products_count");
            base.OnModelCreating(modelBuilder);
        }
    }
}
