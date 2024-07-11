using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tiyatroff.Models;

public partial class DbTiyatroContext : DbContext
{
    public DbTiyatroContext()
    {
    }

    public DbTiyatroContext(DbContextOptions<DbTiyatroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Biletler> Biletlers { get; set; }

    public virtual DbSet<Gosterim> Gosterims { get; set; }

    public virtual DbSet<Ilceler> Ilcelers { get; set; }

    public virtual DbSet<Kullanici> Kullanicis { get; set; }

    public virtual DbSet<Oyuncular> Oyunculars { get; set; }

    public virtual DbSet<Oyunlar> Oyunlars { get; set; }

    public virtual DbSet<Salonlar> Salonlars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Biletler>(entity =>
        {
            entity.Property(e => e.BiletId).ValueGeneratedNever();
            entity.Property(e => e.Fiyat).IsFixedLength();

            entity.HasOne(d => d.Gosterim).WithMany(p => p.Biletlers).HasConstraintName("FK_biletler_gosterim");
        });

        modelBuilder.Entity<Gosterim>(entity =>
        {
            entity.Property(e => e.GosterimId).ValueGeneratedNever();
            entity.Property(e => e.Fiyat).IsFixedLength();

            entity.HasOne(d => d.Oyun).WithMany(p => p.Gosterims).HasConstraintName("FK_gosterim_oyunlar");

            entity.HasOne(d => d.Salon).WithMany(p => p.Gosterims).HasConstraintName("FK_gosterim_salonlar");

            entity.HasOne(d => d.Ilce).WithMany(p => p.Gosterims).HasConstraintName("FK_gosterim_ilceler");
        });

        modelBuilder.Entity<Ilceler>(entity =>
        {
            entity.Property(e => e.IlceId).ValueGeneratedNever();
            entity.Property(e => e.IlceAd).IsFixedLength();
        });

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.Property(e => e.KullaniciId).ValueGeneratedNever();
            entity.Property(e => e.Eposta).IsFixedLength();
            entity.Property(e => e.Sifre).IsFixedLength();
        });

        modelBuilder.Entity<Oyuncular>(entity =>
        {
            entity.Property(e => e.OyuncuId).ValueGeneratedNever();
            entity.Property(e => e.OyuncuAd).IsFixedLength();
            entity.Property(e => e.OyuncuFoto).IsFixedLength();
            entity.Property(e => e.TelNo).IsFixedLength();
            entity.Property(e => e.Universite).IsFixedLength();
        });

        modelBuilder.Entity<Oyunlar>(entity =>
        {
            entity.Property(e => e.OyunId).ValueGeneratedNever();
            entity.Property(e => e.OyunAd).IsFixedLength();
            entity.Property(e => e.OyunFoto).IsFixedLength();
            entity.Property(e => e.OyunTur).IsFixedLength();
            entity.Property(e => e.Sure).IsFixedLength();
            entity.Property(e => e.Yonetmen).IsFixedLength();
        });

        modelBuilder.Entity<Salonlar>(entity =>
        {
            entity.Property(e => e.SalonId).ValueGeneratedNever();
            entity.Property(e => e.SalonAd).IsFixedLength();
            entity.Property(e => e.SalonAdres).IsFixedLength();
            entity.Property(e => e.SalonNo).IsFixedLength();

            entity.HasOne(d => d.Ilce).WithMany(p => p.Salonlars).HasConstraintName("FK_salonlar_ilceler");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
