using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UdemyEFCore.DatabaseFirstByScaffold.Models
{
    public partial class UdemyEFCoreDatabaseFirstDBContext : DbContext
    {
        public UdemyEFCoreDatabaseFirstDBContext()
        {
        }

        public UdemyEFCoreDatabaseFirstDBContext(DbContextOptions<UdemyEFCoreDatabaseFirstDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-SKMS1FNM;Database=UdemyEFCoreDatabaseFirstDB;Trusted_Connection=True;User Id=sa;Password=newBeginning153");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
