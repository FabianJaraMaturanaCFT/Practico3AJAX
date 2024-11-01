﻿// <auto-generated />
using System;
using EVA3AJAX.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EVA3AJAX.Migrations
{
    [DbContext(typeof(ProyectoDBContext))]
    [Migration("20241101082614_Cuarta")]
    partial class Cuarta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EVA3AJAX.Models.AsignacionHerramienta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaAsignacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnidadHerramientaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AsignacionHerramientas");
                });

            modelBuilder.Entity("EVA3AJAX.Models.Herramienta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CantidadTotal")
                        .HasColumnType("int");

                    b.Property<int>("Disponibles")
                        .HasColumnType("int");

                    b.Property<int>("IdMarca")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Herramientas");
                });

            modelBuilder.Entity("EVA3AJAX.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Makita"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Bosch"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "DeWalt"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Black & Decker"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Stanley"
                        },
                        new
                        {
                            Id = 6,
                            Nombre = "Milwaukee"
                        },
                        new
                        {
                            Id = 7,
                            Nombre = "Hitachi"
                        },
                        new
                        {
                            Id = 8,
                            Nombre = "Ryobi"
                        },
                        new
                        {
                            Id = 9,
                            Nombre = "Metabo"
                        },
                        new
                        {
                            Id = 10,
                            Nombre = "Hilti"
                        },
                        new
                        {
                            Id = 11,
                            Nombre = "Ridgid"
                        },
                        new
                        {
                            Id = 12,
                            Nombre = "Craftsman"
                        },
                        new
                        {
                            Id = 13,
                            Nombre = "Porter-Cable"
                        },
                        new
                        {
                            Id = 14,
                            Nombre = "Festool"
                        },
                        new
                        {
                            Id = 15,
                            Nombre = "Worx"
                        },
                        new
                        {
                            Id = 16,
                            Nombre = "Kobalt"
                        },
                        new
                        {
                            Id = 17,
                            Nombre = "Skil"
                        },
                        new
                        {
                            Id = 18,
                            Nombre = "Dremel"
                        },
                        new
                        {
                            Id = 19,
                            Nombre = "Einhell"
                        },
                        new
                        {
                            Id = 20,
                            Nombre = "Rok"
                        });
                });

            modelBuilder.Entity("EVA3AJAX.Models.UnidadHerramienta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HerramientaId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UnidadHerramientas");
                });

            modelBuilder.Entity("EVA3AJAX.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
