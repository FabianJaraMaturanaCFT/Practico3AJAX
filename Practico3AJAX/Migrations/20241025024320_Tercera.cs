using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practico3AJAX.Migrations
{
    public partial class Tercera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 3, "Puma" },
                    { 4, "Bosch" },
                    { 5, "Makita" },
                    { 6, "Dewalt" },
                    { 7, "Stanley" },
                    { 8, "Black & Decker" },
                    { 9, "Hilti" },
                    { 10, "Hitachi" },
                    { 11, "Milwaukee" },
                    { 12, "Ryobi" },
                    { 13, "Craftsman" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 4, "ana.hernandez@gmail.com", "Ana", "961145111" },
                    { 5, "carlos.martinez@hotmail.com", "Carlos", "961142222" },
                    { 6, "lucia.gomez@yahoo.com", "Lucia", "961144333" },
                    { 7, "raul.rodriguez@outlook.com", "Raul", "961143444" },
                    { 8, "sofia.lopez@gmail.com", "Sofia", "961145555" },
                    { 9, "miguel.sanchez@hotmail.com", "Miguel", "961142666" },
                    { 10, "isabel.perez@gmail.com", "Isabel", "961144777" },
                    { 11, "andres.garcia@outlook.com", "Andres", "961143888" },
                    { 12, "marta.flores@yahoo.com", "Marta", "961145999" },
                    { 13, "javier.diaz@hotmail.com", "Javier", "961142000" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
