using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.ReleationShipsExample.DAL
{
    public class AppDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        //Database Generated Attribute için yorum satırı - example
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextInitializer.Build();
            optionsBuilder.UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region  One to Many
            // One to Many
            //modelBuilder.Entity<Category>().HasMany(x => x.Product).WithOne(x => x.Category).HasForeignKey(x => x.Category_Id); // Product model ın
            //altında ForeingKey belirttim migration kaldır, kur yaptık
            #endregion

            #region One to One 
            //One to One Fluent Api (Attributes attığım için ProductFeature a bunu satırı pasife çektim)
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.ProductRef_Id);

            //One to One ---- PrimaryKey = ForignKey (Birden bire ilişkide tekrar bir ref id belirtmeye gerek yok, best practices için bu senaryoda
            //product ın auto increment dan aldığı id yi ProductFeature a yansıtmak yeterli olacaktır)
            //---- Attribute verdim bunu, pasife çektim. ProductFeature altında -- [ForeignKey("Product")]
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.ProductFeatureId);

            #endregion

            #region Many to Many

            //Many to Many
            //modelBuilder.Entity<Student>().
            //    HasMany(x => x.Teachers).
            //    WithMany(x => x.Students)
            //    .UsingEntity<Dictionary<string, object>>(
            //    "StudentTeacherTable",
            //    x=>x.HasOne<Teacher>().WithMany().HasForeignKey("Teacher_Id").HasConstraintName("FK__TeacherId"),
            //    x=>x.HasOne<Student>().WithMany().HasForeignKey("Student_Id").HasConstraintName("FK__StudentId")
            //    );

            #endregion

            #region Delete Behaviors
            //Cascade yerine Restrict yaptık, cascade bu senaryoda kategoriye bağlı ürünlerinde silinmesine izin verir - restrict exception atar silinmesine izin vermez
            //modelBuilder.Entity<Category>()
            //    .HasMany(x => x.Products)
            //    .WithOne(x => x.Category)
            //    .HasForeignKey(x => x.CategoryId).
            //    OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<Category>()
            //    .HasMany(x => x.Products)
            //    .WithOne(x => x.Category)
            //    .HasForeignKey(x => x.CategoryId).
            //    OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region Database Generated Attribute ++++ Price * Kdv

            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).HasComputedColumnSql("[Price]*[Kdv]");
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedOnAdd();//Identity
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedOnAddOrUpdate();//Computed
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedNever();//None

            #endregion


            base.OnModelCreating(modelBuilder);
        }

    }
}
