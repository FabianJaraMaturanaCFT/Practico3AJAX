﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Practico3AJAX.Data;

#nullable disable

namespace Practico3AJAX.Migrations
{
    [DbContext(typeof(ProyectoDBContext))]
    [Migration("20241025024320_Tercera")]
    partial class Tercera
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Practico3AJAX.Models.AsignacionHerramienta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAsignacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaDevolucion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUnidadHerramienta")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUnidadHerramienta");

                    b.HasIndex("IdUsuario");

                    b.ToTable("AsignacionHerramientas");
                });

            modelBuilder.Entity("Practico3AJAX.Models.Herramienta", b =>
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

            modelBuilder.Entity("Practico3AJAX.Models.MantenimientoHerramienta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EstadoMantenimiento")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUnidadHerramienta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUnidadHerramienta");

                    b.ToTable("MantenimientoHerramientas");
                });

            modelBuilder.Entity("Practico3AJAX.Models.Marca", b =>
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
                            Id = 3,
                            Nombre = "Puma"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Bosch"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Makita"
                        },
                        new
                        {
                            Id = 6,
                            Nombre = "Dewalt"
                        },
                        new
                        {
                            Id = 7,
                            Nombre = "Stanley"
                        },
                        new
                        {
                            Id = 8,
                            Nombre = "Black & Decker"
                        },
                        new
                        {
                            Id = 9,
                            Nombre = "Hilti"
                        },
                        new
                        {
                            Id = 10,
                            Nombre = "Hitachi"
                        },
                        new
                        {
                            Id = 11,
                            Nombre = "Milwaukee"
                        },
                        new
                        {
                            Id = 12,
                            Nombre = "Ryobi"
                        },
                        new
                        {
                            Id = 13,
                            Nombre = "Craftsman"
                        });
                });

            modelBuilder.Entity("Practico3AJAX.Models.UnidadHerramienta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaMantencion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaRetornoBodega")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdModelo")
                        .HasColumnType("int");

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdModelo");

                    b.ToTable("UnidadHerramientas");
                });

            modelBuilder.Entity("Practico3AJAX.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Email = "matu69.ssj@gmail.com",
                            Nombre = "Fabian",
                            Telefono = "961143118"
                        },
                        new
                        {
                            Id = 3,
                            Email = "AAA.12@gmail.com",
                            Nombre = "Edgar",
                            Telefono = "961145454"
                        },
                        new
                        {
                            Id = 4,
                            Email = "ana.hernandez@gmail.com",
                            Nombre = "Ana",
                            Telefono = "961145111"
                        },
                        new
                        {
                            Id = 5,
                            Email = "carlos.martinez@hotmail.com",
                            Nombre = "Carlos",
                            Telefono = "961142222"
                        },
                        new
                        {
                            Id = 6,
                            Email = "lucia.gomez@yahoo.com",
                            Nombre = "Lucia",
                            Telefono = "961144333"
                        },
                        new
                        {
                            Id = 7,
                            Email = "raul.rodriguez@outlook.com",
                            Nombre = "Raul",
                            Telefono = "961143444"
                        },
                        new
                        {
                            Id = 8,
                            Email = "sofia.lopez@gmail.com",
                            Nombre = "Sofia",
                            Telefono = "961145555"
                        },
                        new
                        {
                            Id = 9,
                            Email = "miguel.sanchez@hotmail.com",
                            Nombre = "Miguel",
                            Telefono = "961142666"
                        },
                        new
                        {
                            Id = 10,
                            Email = "isabel.perez@gmail.com",
                            Nombre = "Isabel",
                            Telefono = "961144777"
                        },
                        new
                        {
                            Id = 11,
                            Email = "andres.garcia@outlook.com",
                            Nombre = "Andres",
                            Telefono = "961143888"
                        },
                        new
                        {
                            Id = 12,
                            Email = "marta.flores@yahoo.com",
                            Nombre = "Marta",
                            Telefono = "961145999"
                        },
                        new
                        {
                            Id = 13,
                            Email = "javier.diaz@hotmail.com",
                            Nombre = "Javier",
                            Telefono = "961142000"
                        });
                });

            modelBuilder.Entity("Practico3AJAX.Models.AsignacionHerramienta", b =>
                {
                    b.HasOne("Practico3AJAX.Models.UnidadHerramienta", "UnidadHerramienta")
                        .WithMany()
                        .HasForeignKey("IdUnidadHerramienta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Practico3AJAX.Models.Usuario", "Usuario")
                        .WithMany("Asignaciones")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UnidadHerramienta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Practico3AJAX.Models.MantenimientoHerramienta", b =>
                {
                    b.HasOne("Practico3AJAX.Models.UnidadHerramienta", "UnidadHerramienta")
                        .WithMany()
                        .HasForeignKey("IdUnidadHerramienta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UnidadHerramienta");
                });

            modelBuilder.Entity("Practico3AJAX.Models.UnidadHerramienta", b =>
                {
                    b.HasOne("Practico3AJAX.Models.Herramienta", "Herramienta")
                        .WithMany("UnidadHerramientas")
                        .HasForeignKey("IdModelo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Herramienta");
                });

            modelBuilder.Entity("Practico3AJAX.Models.Herramienta", b =>
                {
                    b.Navigation("UnidadHerramientas");
                });

            modelBuilder.Entity("Practico3AJAX.Models.Usuario", b =>
                {
                    b.Navigation("Asignaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
