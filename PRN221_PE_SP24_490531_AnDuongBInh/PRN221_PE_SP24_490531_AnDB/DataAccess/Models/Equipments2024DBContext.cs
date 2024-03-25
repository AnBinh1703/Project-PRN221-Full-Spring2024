using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Models
{
    public partial class Equipments2024DBContext : DbContext
    {
        public Equipments2024DBContext()
        {
        }

        public Equipments2024DBContext(DbContextOptions<Equipments2024DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Equipment> Equipments { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasKey(e => e.EqId);

                entity.Property(e => e.EqId)
                    .ValueGeneratedNever()
                    .HasColumnName("EqID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.EqCode).HasMaxLength(50);

                entity.Property(e => e.EqName).HasMaxLength(150);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.SupplierName).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Rooms_Equipments");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoomID");

                entity.Property(e => e.Location).HasMaxLength(150);

                entity.Property(e => e.RoomName).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
