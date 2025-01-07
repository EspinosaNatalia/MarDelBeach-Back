using Microsoft.EntityFrameworkCore;
using System.Numerics;
using tesisv2_back.Models;

namespace tesisv2_back.Data
{
    public class ApplicationDbContext : DbContext
    {
       
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            // Declaración de tablas (DbSets)
            public DbSet<Playa> Playa { get; set; } = null!;
            public DbSet<Actividad> Actividad { get; set; } = null!;
            public DbSet<Usuario> Usuario { get; set; } = null!;
            public DbSet<Valoracion> Valoraciones { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Configuración de las relaciones
                modelBuilder.Entity<Valoracion>()
                    .HasOne(v => v.Playa)
                    .WithMany(p => p.Valoraciones)
                    .HasForeignKey(v => v.PlayaId)
                    .OnDelete(DeleteBehavior.Cascade); // Relación con Playa

                modelBuilder.Entity<Valoracion>()
                    .HasOne(v => v.Actividad)
                    .WithMany(a => a.Valoraciones)
                    .HasForeignKey(v => v.ActividadId)
                    .OnDelete(DeleteBehavior.Cascade); // Relación con Actividad

                modelBuilder.Entity<Playa>().ToTable("playa");
                modelBuilder.Entity<Actividad>().ToTable("actividad");
                modelBuilder.Entity<Usuario>().ToTable("usuario");

                // Datos iniciales (para ejemplo)
                modelBuilder.Entity<Playa>().HasData(
                    new Playa
                    {
                        Id = 1,
                        Nombre = "Playa Grande",
                        Direccion = "Avenida Costanera 123",
                        Capacidad = 500,
                        Zona = "Constitución",
                        Imagenes = "assets/img/carr1.jpg,assets/img/carr2.jpg,assets/img/carr3.jpg",
                        Caracteristicas = "Arena fina,Olas suaves,Ideal para familias",
                        Servicios = "Restaurantes cercanos,Alquiler de sombrillas",
                        Accesos = "Accesible en auto,Transporte público cercano",
                        PromedioValoracion = 4.2m
                    },
                    new Playa
                    {
                        Id = 2,
                        Nombre = "Punta Mogotes",
                        Direccion = "Avenida Central 456",
                        Capacidad = 600,
                        Zona = "Zona Norte",
                        Imagenes = "assets/img/login.jpg,assets/img/recomendaciones.jpeg,assets/img/mar.jpg",
                        Caracteristicas = "Agua limpia,Olas tranquilas,Arena blanca",
                        Servicios = "Parking cercano,Restaurantes,Alquiler de sombrillas",
                        Accesos = "Transporte público cercano,Accesible para discapacitados",
                        PromedioValoracion = 3.8m
                    }
                );

            modelBuilder.Entity<Actividad>().HasData(
                new Actividad
                {
                    Id = 1,
                    Nombre = "Surf en Playa Grande",
                    Descripcion = "Clases de surf para principiantes.",
                    Imagen = "assets/img/bueno.png,assets/img/recomendaciones.jpeg,assets/img/login.jpg",
                    Direccion = "Playa Grande, Mar del Plata",
                    Zona = "Constitución",
                    Caracteristicas = "Ideal para principiantes,Equipo incluido,Clases grupales",
                    Servicios = "Vestuario,Duchas,Alquiler de equipos",
                    Accesos = "Acceso por la playa,Transporte público cercano",
                    PromedioValoracion = 4.8m
                },
                 new Actividad
                 {
                     Id = 2,
                     Nombre = "Teatro Radio City",
                     Descripcion = "Teatro Radio City, con 3 salas.",
                     Imagen = "assets/img/radiocity.jpg,assets/img/radio2.jpg,assets/img/radio3.jpg",
                     Direccion = "San Luis 2544",
                     Zona = "Centro",
                     Caracteristicas = "3 increíbles salas: Radio City, Melany y Roxy",
                     Servicios = "Comedor, boletería",
                     Accesos = "Por calle San Luis",
                     PromedioValoracion = 2.5m
                 }

            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    UID = "12345",
                    Email = "user1@example.com",
                    Nombre = "Usuario Uno",
                    FechaRegistro = DateTime.UtcNow
                }
            );
        }
    }
}
