using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.Loadings.Entity;

namespace UdemyEFCore.Loadings.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextInitializer.Build();
            //optionsBuilder.UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));
            //To Lazy Loading
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseLazyLoadingProxies().UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            #region Entity Properties

            //modelBuilder.Entity<Product>().Ignore(x => x.Barcode);
            //modelBuilder.Entity<Product>().Property(x => x.Name).IsUnicode(false);
            //modelBuilder.Entity<Product>().Property(x => x.Url).HasColumnType("nvarchar(200)").HasColumnName("Alsanaurl");

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
