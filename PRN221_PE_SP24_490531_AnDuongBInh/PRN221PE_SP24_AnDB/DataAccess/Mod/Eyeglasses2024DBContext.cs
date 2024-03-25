using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Models
{
    public partial class Eyeglasses2024DBContext : DbContext
    {
        public Eyeglasses2024DBContext()
        {
        }

        public Eyeglasses2024DBContext(DbContextOptions<Eyeglasses2024DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Eyeglass> Eyeglasses { get; set; } = null!;
        public virtual DbSet<LensType> LensTypes { get; set; } = null!;
        public virtual DbSet<StoreAccount> StoreAccounts { get; set; } = null!;

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
            modelBuilder.Entity<Eyeglass>(entity =>
            {
                entity.HasKey(e => e.EyeglassesId)
                    .HasName("PK__Eyeglass__93A83C7BF24D3D44");

                entity.Property(e => e.EyeglassesId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EyeglassesDescription).HasMaxLength(250);

                entity.Property(e => e.EyeglassesName).HasMaxLength(100);

                entity.Property(e => e.FrameColor).HasMaxLength(50);

                entity.Property(e => e.LensTypeId).HasMaxLength(30);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.LensType)
                    .WithMany(p => p.Eyeglasses)
                    .HasForeignKey(d => d.LensTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Eyeglasse__LensT__3C69FB99");
            });

            modelBuilder.Entity<LensType>(entity =>
            {
                entity.ToTable("LensType");

                entity.Property(e => e.LensTypeId).HasMaxLength(30);

                entity.Property(e => e.LensTypeDescription).HasMaxLength(250);

                entity.Property(e => e.LensTypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<StoreAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__StoreAcc__349DA586472FCB0F");

                entity.ToTable("StoreAccount");

                entity.HasIndex(e => e.EmailAddress, "UQ__StoreAcc__49A1474059850CFE")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("AccountID");

                entity.Property(e => e.AccountPassword).HasMaxLength(40);

                entity.Property(e => e.EmailAddress).HasMaxLength(60);

                entity.Property(e => e.FullName).HasMaxLength(60);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
