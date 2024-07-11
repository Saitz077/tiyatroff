using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ders.Models;

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
            entity.Property(e => e.KategoriId).ValueGeneratedNever();
            entity.Property(e => e.KategoriAd).IsFixedLength();
        });

        modelBuilder.Entity<UrunTbl>(entity =>
        {
            entity.Property(e => e.UrunId).ValueGeneratedNever();
            entity.Property(e => e.UrunAd).IsFixedLength();

            entity.HasOne(d => d.Kategori).WithMany(p => p.UrunTbls).HasConstraintName("FK_urun_tbl_urun_tbl");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
