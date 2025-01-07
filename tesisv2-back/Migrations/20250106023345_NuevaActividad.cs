using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tesisv2_back.Migrations
{
    public partial class NuevaActividad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PlayaId",
                table: "Valoraciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActividadId",
                table: "Valoraciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "actividad",
                columns: new[] { "Id", "Accesos", "Caracteristicas", "Descripcion", "Direccion", "Imagen", "Nombre", "PromedioValoracion", "Servicios", "Zona" },
                values: new object[] { 2, "Por calle San Luis", "3 increíbles salas: Radio City, Melany y Roxy", "Teatro Radio City, con 3 salas.", "San Luis 2544", "assets/img/radiocity.jpg,assets/img/radio2.jpg,assets/img/radio3.jpg", "Teatro Radio City", 2.5m, "Comedor, boletería", "Centro" });

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 1, 6, 2, 33, 45, 27, DateTimeKind.Utc).AddTicks(940));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "actividad",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "PlayaId",
                table: "Valoraciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActividadId",
                table: "Valoraciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 1, 4, 20, 35, 25, 407, DateTimeKind.Utc).AddTicks(5245));
        }
    }
}
