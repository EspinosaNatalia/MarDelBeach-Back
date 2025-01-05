using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tesisv2_back.Migrations
{
    public partial class valoracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Valoraciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estrellas = table.Column<int>(type: "int", nullable: false),
                    PlayaId = table.Column<int>(type: "int", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valoraciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valoraciones_actividad_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "actividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Valoraciones_playa_PlayaId",
                        column: x => x.PlayaId,
                        principalTable: "playa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 1, 4, 20, 35, 25, 407, DateTimeKind.Utc).AddTicks(5245));

            migrationBuilder.CreateIndex(
                name: "IX_Valoraciones_ActividadId",
                table: "Valoraciones",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Valoraciones_PlayaId",
                table: "Valoraciones",
                column: "PlayaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Valoraciones");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 12, 31, 17, 6, 15, 789, DateTimeKind.Utc).AddTicks(7826));
        }
    }
}
