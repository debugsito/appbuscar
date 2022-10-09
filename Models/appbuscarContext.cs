using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace appbuscar.Models
{
    public partial class appbuscarContext : DbContext
    {
        public appbuscarContext()
        {
        }

        public appbuscarContext(DbContextOptions<appbuscarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buses> Buses { get; set; } = null!;
        public virtual DbSet<Roles> Roles { get; set; } = null!;
        public virtual DbSet<RouteTickets> RouteTickets { get; set; } = null!;
        public virtual DbSet<Routes> Routes { get; set; } = null!;
        public virtual DbSet<ScheduleRoutes> ScheduleRoutes { get; set; } = null!;
        public virtual DbSet<Users> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Initial Catalog=AppBuscar;User ID=sa;Password=Sanaso12!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buses>(entity =>
            {
                entity.ToTable("buses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brand");

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(0)
                    .HasColumnName("created_at");

                entity.Property(e => e.Model)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.NumberSeats).HasColumnName("number_seats");

                entity.Property(e => e.Plate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("plate");

                entity.Property(e => e.ProductionYear).HasColumnName("production_year");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(0)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(0)
                    .HasColumnName("created_at");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(0)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<RouteTickets>(entity =>
            {
                entity.ToTable("route_tickets");

                entity.HasIndex(e => e.ScheduleRouteId, "schedule_route_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(0)
                    .HasColumnName("created_at");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("document_number");

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.NumberSeat).HasColumnName("number_seat");

                entity.Property(e => e.ScheduleRouteId).HasColumnName("schedule_route_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(0)
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ScheduleRoute)
                    .WithMany(p => p.RouteTickets)
                    .HasForeignKey(d => d.ScheduleRouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_tickets_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RouteTickets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_tickets_ibfk_2");
            });

            modelBuilder.Entity<Routes>(entity =>
            {
                entity.ToTable("routes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(0)
                    .HasColumnName("created_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.StationEnd)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("station_end");

                entity.Property(e => e.StationStart)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("station_start");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(0)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<ScheduleRoutes>(entity =>
            {
                entity.ToTable("schedule_routes");

                entity.HasIndex(e => e.BusId, "bus_id");

                entity.HasIndex(e => e.RouteId, "route_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AvailableSeats).HasColumnName("available_seats");

                entity.Property(e => e.BusId).HasColumnName("bus_id");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(0)
                    .HasColumnName("created_at");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.Property(e => e.ScheduleEnd)
                    .HasPrecision(0)
                    .HasColumnName("schedule_end");

                entity.Property(e => e.ScheduleStart)
                    .HasPrecision(0)
                    .HasColumnName("schedule_start");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(0)
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.ScheduleRoutes)
                    .HasForeignKey(d => d.BusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedule_routes_ibfk_2");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.ScheduleRoutes)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedule_routes_ibfk_1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.RolId, "rol_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(0)
                    .HasColumnName("created_at");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("document_number");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(0)
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
