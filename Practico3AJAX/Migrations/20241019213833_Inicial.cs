using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practico3AJAX.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Herramientas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CantidadTotal = table.Column<int>(type: "int", nullable: false),
                    Disponibles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herramientas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadHerramientas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroSerie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HerramientaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadHerramientas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadHerramientas_Herramientas_HerramientaId",
                        column: x => x.HerramientaId,
                        principalTable: "Herramientas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsignacionHerramientas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadHerramientaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionHerramientas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsignacionHerramientas_UnidadHerramientas_UnidadHerramientaId",
                        column: x => x.UnidadHerramientaId,
                        principalTable: "UnidadHerramientas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignacionHerramientas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MantenimientoHerramientas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadHerramientaId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MantenimientoHerramientas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MantenimientoHerramientas_UnidadHerramientas_UnidadHerramientaId",
                        column: x => x.UnidadHerramientaId,
                        principalTable: "UnidadHerramientas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionHerramientas_UnidadHerramientaId",
                table: "AsignacionHerramientas",
                column: "UnidadHerramientaId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionHerramientas_UsuarioId",
                table: "AsignacionHerramientas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MantenimientoHerramientas_UnidadHerramientaId",
                table: "MantenimientoHerramientas",
                column: "UnidadHerramientaId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadHerramientas_HerramientaId",
                table: "UnidadHerramientas",
                column: "HerramientaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignacionHerramientas");

            migrationBuilder.DropTable(
                name: "MantenimientoHerramientas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "UnidadHerramientas");

            migrationBuilder.DropTable(
                name: "Herramientas");
        }
    }
}
