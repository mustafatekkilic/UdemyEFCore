using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.OwnedEntityTypes.Entity;

namespace UdemyEFCore.OwnedEntityTypes.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextInitializer.Build();
            optionsBuilder.UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Manager>().OwnsOne(x => x.Person);
            //modelBuilder.Entity<Employee>().OwnsOne(x => x.Person);
            modelBuilder.Entity<Manager>().OwnsOne(x => x.Person, item =>
            {
                item.Property(x=>x.FirstName).HasColumnName("FirstName");
                item.Property(x=>x.LastName).HasColumnName("LastName");
                item.Property(x=>x.Age).HasColumnName("Age");
            });
            modelBuilder.Entity<Employee>().OwnsOne(x => x.Person);
            base.OnModelCreating(modelBuilder);
        }
    }
}
