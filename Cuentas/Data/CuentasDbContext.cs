using System;
using System.Collections.Generic;
using Cuentas.Models;
using Microsoft.EntityFrameworkCore;

namespace Cuentas.Data;

public partial class CuentasDbContext : DbContext
{
    public CuentasDbContext()
    {
    }

    public CuentasDbContext(DbContextOptions<CuentasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cuenta> Cuentas { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Monedum> Moneda { get; set; }

    public virtual DbSet<TasaCambio> TasaCambios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PK__Cuentas__D41FD706E1AD022D");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.NumeroCuenta).HasMaxLength(15);
            entity.Property(e => e.Saldo).HasColumnType("decimal(9, 6)");

            entity.HasOne(d => d.IdDivisionNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdDivision)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_division");

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdMoneda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Moneda");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.IdDivision).HasName("PK__Division__542428D0A4F69A6F");

            entity.ToTable("Division");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Monedum>(entity =>
        {
            entity.HasKey(e => e.IdMoneda).HasName("PK__Moneda__AA6906718EDC7F68");

            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Valor).HasColumnType("decimal(9, 6)");
        });

        modelBuilder.Entity<TasaCambio>(entity =>
        {
            entity.HasKey(e => e.IdCambio).HasName("PK__tasa_cam__D7247A1AFEA28F02");

            entity.ToTable("tasa_cambio");

            entity.Property(e => e.IdCambio).HasColumnName("idCambio");
            entity.Property(e => e.TasaCambio1).HasColumnName("TasaCambio");

            entity.HasOne(d => d.IdMonedaDestinoNavigation).WithMany(p => p.TasaCambioIdMonedaDestinoNavigations)
                .HasForeignKey(d => d.IdMonedaDestino)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MonedaDestino");

            entity.HasOne(d => d.IdMonedaOrigenNavigation).WithMany(p => p.TasaCambioIdMonedaOrigenNavigations)
                .HasForeignKey(d => d.IdMonedaOrigen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MonedaOrigen");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
