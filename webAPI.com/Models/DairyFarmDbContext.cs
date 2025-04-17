using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webAPI.com.Models;

public partial class DairyFarmDbContext : DbContext
{
    public DairyFarmDbContext()
    {
    }

    public DairyFarmDbContext(DbContextOptions<DairyFarmDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cow> Cows { get; set; }

    public virtual DbSet<Feed> Feeds { get; set; }

    public virtual DbSet<HealthRecord> HealthRecords { get; set; }

    public virtual DbSet<MilkProduction> MilkProductions { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cow>(entity =>
        {
            entity.HasKey(e => e.CowId).HasName("PK__Cows__E32F8728857750AB");

            entity.Property(e => e.CowId).HasColumnName("CowID");
            entity.Property(e => e.Breed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HealthStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Feed>(entity =>
        {
            entity.HasKey(e => e.FeedId).HasName("PK__Feed__1586DF751D3C2329");

            entity.ToTable("Feed");

            entity.Property(e => e.FeedId).HasColumnName("FeedID");
            entity.Property(e => e.CowId).HasColumnName("CowID");
            entity.Property(e => e.FeedType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.QuantityKg).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Cow).WithMany(p => p.Feeds)
                .HasForeignKey(d => d.CowId)
                .HasConstraintName("FK__Feed__CowID__4E88ABD4");
        });

        modelBuilder.Entity<HealthRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__HealthRe__FBDF78C97B511F40");

            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.CowId).HasColumnName("CowID");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.VetName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Cow).WithMany(p => p.HealthRecords)
                .HasForeignKey(d => d.CowId)
                .HasConstraintName("FK__HealthRec__CowID__5165187F");
        });

        modelBuilder.Entity<MilkProduction>(entity =>
        {
            entity.HasKey(e => e.ProductionId).HasName("PK__MilkProd__D5D9A2F55051149A");

            entity.ToTable("MilkProduction");

            entity.Property(e => e.ProductionId).HasColumnName("ProductionID");
            entity.Property(e => e.CowId).HasColumnName("CowID");
            entity.Property(e => e.QuantityLiters).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Cow).WithMany(p => p.MilkProductions)
                .HasForeignKey(d => d.CowId)
                .HasConstraintName("FK__MilkProdu__CowID__4BAC3F29");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF7CA74E7A2");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
