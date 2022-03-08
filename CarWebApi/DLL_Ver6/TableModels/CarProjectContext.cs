﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DLL_Ver6
{
    public partial class CarProjectContext : DbContext
    {
        public CarProjectContext()
        {
        }

        public CarProjectContext(DbContextOptions<CarProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarInfo> CarInfos { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<RentTable> RentTables { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=laptop-8e9nlphh\\sqlexpress;Initial Catalog=CarProject;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CarInfo>(entity =>
            {
                entity.HasKey(e => e.CarNum);

                entity.ToTable("CarInfo");

                entity.Property(e => e.CarNum).ValueGeneratedNever();

                entity.Property(e => e.Available)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CarType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rentable)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.HasKey(e => e.CarNum);

                entity.ToTable("CarType");

                entity.Property(e => e.CarNum).ValueGeneratedNever();

                entity.Property(e => e.CarId).ValueGeneratedOnAdd();

                entity.Property(e => e.Dprice).HasColumnName("DPrice");

                entity.Property(e => e.Manufactor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CarNumNavigation)
                    .WithOne(p => p.CarTypeNavigation)
                    .HasForeignKey<CarType>(d => d.CarNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarType_CarInfo");
            });

            modelBuilder.Entity<RentTable>(entity =>
            {
                entity.HasKey(e => e.OrderNum);

                entity.ToTable("RentTable");

                entity.Property(e => e.RealReturnDate).HasMaxLength(50);

                entity.Property(e => e.ReturnDate).HasMaxLength(50);

                entity.Property(e => e.StartRentDate)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CarNumNavigation)
                    .WithMany(p => p.RentTables)
                    .HasForeignKey(d => d.CarNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentTable_CarInfo");

                entity.HasOne(d => d.UserTzNavigation)
                    .WithMany(p => p.RentTables)
                    .HasForeignKey(d => d.UserTz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentTable_UserTable");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UserTz)
                    .HasName("PK_UserTable_1");

                entity.ToTable("UserTable");

                entity.HasIndex(e => e.UserTz, "IX_UserTable")
                    .IsUnique();

                entity.HasIndex(e => e.NickName, "IX_UserTable_1")
                    .IsUnique();

                entity.Property(e => e.UserTz).ValueGeneratedNever();

                entity.Property(e => e.Bday)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nickName");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
