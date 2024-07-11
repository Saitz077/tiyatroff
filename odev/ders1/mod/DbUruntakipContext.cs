using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ders1.mod;

public partial class DbUruntakipContext : DbContext
{
    public DbUruntakipContext()
    {
    }

    public DbUruntakipContext(DbContextOptions<DbUruntakipContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KategoriTbl> KategoriTbls { get; set; }

    public virtual DbSet<UrunTbl> UrunTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-CEB7IOT\\SQLEXPRESS01;Initial Catalog=db_uruntakip;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KategoriTbl>(entity =>
        {
            entity.HasKey(e => e.KategoriId);

            entity.ToTable("Kategori_Tbl");

            entity.Property(e => e.KategoriId)
                .ValueGeneratedNever()
                .HasColumnName("kategoriId");
            entity.Property(e => e.KategoriAd)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("kategoriAd");
        });

        modelBuilder.Entity<UrunTbl>(entity =>
        {
            entity.HasKey(e => e.UrunId);

            entity.ToTable("urun_tbl");

            entity.Property(e => e.UrunId)
                .ValueGeneratedNever()
                .HasColumnName("urunId");
            entity.Property(e => e.FavoriUrun).HasColumnName("favoriUrun");
            entity.Property(e => e.KategoriId).HasColumnName("kategoriId");
            entity.Property(e => e.UrunAd)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("urunAd");
            entity.Property(e => e.UrunAdet).HasColumnName("urunAdet");
            entity.Property(e => e.UrunFiyat)
                .HasColumnType("money")
                .HasColumnName("urunFiyat");
            entity.Property(e => e.UrunPhoto)
                .HasColumnType("image")
                .HasColumnName("urunPhoto");

            entity.HasOne(d => d.Kategori).WithMany(p => p.UrunTbls)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK_urun_tbl_urun_tbl");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
