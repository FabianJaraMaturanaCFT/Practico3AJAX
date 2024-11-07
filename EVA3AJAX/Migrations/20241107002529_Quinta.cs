using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVA3AJAX.Migrations
{
    public partial class Quinta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRetorno",
                table: "AsignacionHerramientas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRetorno",
                table: "AsignacionHerramientas");
        }
    }
}
