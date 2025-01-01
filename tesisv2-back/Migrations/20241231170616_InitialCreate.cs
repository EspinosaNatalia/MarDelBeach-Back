using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tesisv2_back.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actividad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Servicios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accesos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromedioValoracion = table.Column<decimal>(type: "decimal(5,1)", precision: 5, scale: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actividad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "playa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Zona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagenes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Servicios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accesos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromedioValoracion = table.Column<decimal>(type: "decimal(5,1)", precision: 5, scale: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "actividad",
                columns: new[] { "Id", "Accesos", "Caracteristicas", "Descripcion", "Direccion", "Imagen", "Nombre", "PromedioValoracion", "Servicios", "Zona" },
                values: new object[] { 1, "Acceso por la playa,Transporte público cercano", "Ideal para principiantes,Equipo incluido,Clases grupales", "Clases de surf para principiantes.", "Playa Grande, Mar del Plata", "assets/img/bueno.png,assets/img/recomendaciones.jpeg,assets/img/login.jpg", "Surf en Playa Grande", 4.8m, "Vestuario,Duchas,Alquiler de equipos", "Constitución" });

            migrationBuilder.InsertData(
                table: "playa",
                columns: new[] { "Id", "Accesos", "Capacidad", "Caracteristicas", "Direccion", "Imagenes", "Nombre", "PromedioValoracion", "Servicios", "Zona" },
                values: new object[,]
                {
                    { 1, "Accesible en auto,Transporte público cercano", 500, "Arena fina,Olas suaves,Ideal para familias", "Avenida Costanera 123", "assets/img/carr1.jpg,assets/img/carr2.jpg,assets/img/carr3.jpg", "Playa Grande", 4.2m, "Restaurantes cercanos,Alquiler de sombrillas", "Constitución" },
                    { 2, "Transporte público cercano,Accesible para discapacitados", 600, "Agua limpia,Olas tranquilas,Arena blanca", "Avenida Central 456", "assets/img/login.jpg,assets/img/recomendaciones.jpeg,assets/img/mar.jpg", "Punta Mogotes", 3.8m, "Parking cercano,Restaurantes,Alquiler de sombrillas", "Zona Norte" }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "Id", "Email", "FechaRegistro", "Nombre", "UID" },
                values: new object[] { 1, "user1@example.com", new DateTime(2024, 12, 31, 17, 6, 15, 789, DateTimeKind.Utc).AddTicks(7826), "Usuario Uno", "12345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actividad");

            migrationBuilder.DropTable(
                name: "playa");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
