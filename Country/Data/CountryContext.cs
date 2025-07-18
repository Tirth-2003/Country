using System;
using System.Collections.Generic;
using CountryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryApp.Data;

public partial class CountryContext : DbContext
{
    public CountryContext()
    {
    }

    public CountryContext(DbContextOptions<CountryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Models.Country> Countries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Country;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D1609FC5C7A2B8");

            entity.ToTable("Country");

            entity.Property(e => e.CountryAlpha3Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CountryShortCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CurrencySymbol).HasMaxLength(10);
            entity.Property(e => e.DisplayNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ibanexist).HasColumnName("IBANexist");
            entity.Property(e => e.Ibanlength).HasColumnName("IBANlength");
            entity.Property(e => e.RiskScore).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ShortCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
