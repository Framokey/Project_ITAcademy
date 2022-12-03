using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Project_ITAcademy.Domain.Models;

namespace Project_ITAcademy.DAL
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Route> Routes { get; set; } = null!;
        public virtual DbSet<Station> Stations { get; set; } = null!;
        public virtual DbSet<Train> Trains { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=COMPUCTER;Database=Project_ITAcademy;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Route>(entity =>
            {
                entity.Property(e => e.RouteId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Routes_User");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("Station");

                entity.Property(e => e.StationId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Coordinate1).HasColumnName("Coordinate_1");

                entity.Property(e => e.Coordinate2).HasColumnName("Coordinate_2");

                entity.Property(e => e.RouteId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.StationName)
                    .HasMaxLength(50)
                    .HasColumnName("Station_Name");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Stations)
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK_Station_Routes");
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.ToTable("Train");

                entity.Property(e => e.TrainId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Coordinate1).HasColumnName("Coordinate_1");

                entity.Property(e => e.Coordinate2).HasColumnName("Coordinate_2");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.RouteId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Trains)
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK_Train_Routes");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
