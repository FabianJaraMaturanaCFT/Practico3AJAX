using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVA3AJAX.Migrations
{
    public partial class Tercera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignacionHerramientas_UnidadHerramientas_UnidadHerramientaId",
                table: "AsignacionHerramientas");

            migrationBuilder.DropForeignKey(
                name: "FK_AsignacionHerramientas_Usuarios_UsuarioId",
                table: "AsignacionHerramientas");

            migrationBuilder.DropIndex(
                name: "IX_AsignacionHerramientas_UnidadHerramientaId",
                table: "AsignacionHerramientas");

            migrationBuilder.DropIndex(
                name: "IX_AsignacionHerramientas_UsuarioId",
                table: "AsignacionHerramientas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AsignacionHerramientas_UnidadHerramientaId",
                table: "AsignacionHerramientas",
                column: "UnidadHerramientaId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionHerramientas_UsuarioId",
                table: "AsignacionHerramientas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AsignacionHerramientas_UnidadHerramientas_UnidadHerramientaId",
                table: "AsignacionHerramientas",
                column: "UnidadHerramientaId",
                principalTable: "UnidadHerramientas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AsignacionHerramientas_Usuarios_UsuarioId",
                table: "AsignacionHerramientas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
