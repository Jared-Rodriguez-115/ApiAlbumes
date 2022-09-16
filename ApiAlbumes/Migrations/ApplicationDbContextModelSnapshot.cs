﻿// <auto-generated />
using System;
using ApiAlbumes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiAlbumes.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiAlbumes.Entidades.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Artista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<string>("Duracion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Albumes");
                });

            modelBuilder.Entity("ApiAlbumes.Entidades.Cancion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlbumId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AlbumId1")
                        .HasColumnType("int");

                    b.Property<string>("Compositor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duracion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId1");

                    b.ToTable("Canciones");
                });

            modelBuilder.Entity("ApiAlbumes.Entidades.Cancion", b =>
                {
                    b.HasOne("ApiAlbumes.Entidades.Album", "Album")
                        .WithMany("Canciones")
                        .HasForeignKey("AlbumId1");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("ApiAlbumes.Entidades.Album", b =>
                {
                    b.Navigation("Canciones");
                });
#pragma warning restore 612, 618
        }
    }
}
