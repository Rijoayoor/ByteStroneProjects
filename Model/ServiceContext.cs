using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model;

public partial class ServiceContext : DbContext
{
    public ServiceContext()
    {
    }

    public ServiceContext(DbContextOptions<ServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceExecutive> ServiceExecutives { get; set; }

    public virtual DbSet<ServiceTechnician> ServiceTechnicians { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=servicestationdb;Username=postgres;Password=Rijoayoor");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("booking_pkey");

            entity.ToTable("booking");

            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.BookingDate).HasColumnName("booking_date");
            entity.Property(e => e.CustomerId)
                .ValueGeneratedOnAdd()
                .HasColumnName("customer_id");
            entity.Property(e => e.ExecutiveId)
                .ValueGeneratedOnAdd()
                .HasColumnName("executive_id");
            entity.Property(e => e.ServiceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("service_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TechnicianId)
                .ValueGeneratedOnAdd()
                .HasColumnName("technician_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booking_customer_id_fkey");

            entity.HasOne(d => d.Executive).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ExecutiveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booking_executive_id_fkey");

            entity.HasOne(d => d.Service).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booking_service_id_fkey");

            entity.HasOne(d => d.Technician).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TechnicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booking_technician_id_fkey");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .HasColumnName("contact_number");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .HasColumnName("customer_name");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.VehicleModel)
                .HasMaxLength(20)
                .HasColumnName("vehicle_model");
            entity.Property(e => e.VehicleNumber)
                .HasMaxLength(20)
                .HasColumnName("vehicle_number");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("service_pkey");

            entity.ToTable("service");

            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Price)
                .HasMaxLength(20)
                .HasColumnName("price");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(20)
                .HasColumnName("service_name");
        });

        modelBuilder.Entity<ServiceExecutive>(entity =>
        {
            entity.HasKey(e => e.ExecutiveId).HasName("service_executive_pkey");

            entity.ToTable("service_executive");

            entity.Property(e => e.ExecutiveId).HasColumnName("executive_id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .HasColumnName("contact_number");
            entity.Property(e => e.ExecutiveName)
                .HasMaxLength(20)
                .HasColumnName("executive_name");
        });

        modelBuilder.Entity<ServiceTechnician>(entity =>
        {
            entity.HasKey(e => e.TechnicianId).HasName("service_technician_pkey");

            entity.ToTable("service_technician");

            entity.Property(e => e.TechnicianId).HasColumnName("technician_id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .HasColumnName("contact_number");
            entity.Property(e => e.TechnicianName)
                .HasMaxLength(20)
                .HasColumnName("technician_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
