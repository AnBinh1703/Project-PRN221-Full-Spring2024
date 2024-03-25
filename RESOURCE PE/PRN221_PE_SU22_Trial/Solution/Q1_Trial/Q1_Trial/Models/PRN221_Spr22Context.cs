using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Q1_Trial.Models
{
    public partial class PRN221_Spr22Context : DbContext
    {
        public PRN221_Spr22Context()
        {
        }

        public PRN221_Spr22Context(DbContextOptions<PRN221_Spr22Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;uid=sa;pwd=sa;database=PRN221_Spr22");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Idnumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("IDNumber");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Title);

                entity.Property(e => e.Title)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.Description).HasColumnType("ntext");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.FeeType).HasMaxLength(50);

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.RoomTitle)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Services_Employees");

                entity.HasOne(d => d.RoomTitleNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.RoomTitle)
                    .HasConstraintName("FK_Services_Rooms");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
