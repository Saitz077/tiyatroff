﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using odevalbum.Models;

#nullable disable

namespace odevalbum.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240414221001_Initial Migration ")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("odevalbum.Models.TabloSanat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlbumAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<string>("SanatciBilgi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Yerli")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Sanat");
                });
#pragma warning restore 612, 618
        }
    }
}
