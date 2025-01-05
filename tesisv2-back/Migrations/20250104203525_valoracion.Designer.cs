﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tesisv2_back.Data;

#nullable disable

namespace tesisv2_back.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250104203525_valoracion")]
    partial class valoracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("tesisv2_back.Models.Actividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Accesos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Caracteristicas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PromedioValoracion")
                        .HasPrecision(5, 1)
                        .HasColumnType("decimal(5,1)");

                    b.Property<string>("Servicios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("actividad", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Accesos = "Acceso por la playa,Transporte público cercano",
                            Caracteristicas = "Ideal para principiantes,Equipo incluido,Clases grupales",
                            Descripcion = "Clases de surf para principiantes.",
                            Direccion = "Playa Grande, Mar del Plata",
                            Imagen = "assets/img/bueno.png,assets/img/recomendaciones.jpeg,assets/img/login.jpg",
                            Nombre = "Surf en Playa Grande",
                            PromedioValoracion = 4.8m,
                            Servicios = "Vestuario,Duchas,Alquiler de equipos",
                            Zona = "Constitución"
                        });
                });

            modelBuilder.Entity("tesisv2_back.Models.Playa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Accesos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Caracteristicas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagenes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PromedioValoracion")
                        .HasPrecision(5, 1)
                        .HasColumnType("decimal(5,1)");

                    b.Property<string>("Servicios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("playa", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Accesos = "Accesible en auto,Transporte público cercano",
                            Capacidad = 500,
                            Caracteristicas = "Arena fina,Olas suaves,Ideal para familias",
                            Direccion = "Avenida Costanera 123",
                            Imagenes = "assets/img/carr1.jpg,assets/img/carr2.jpg,assets/img/carr3.jpg",
                            Nombre = "Playa Grande",
                            PromedioValoracion = 4.2m,
                            Servicios = "Restaurantes cercanos,Alquiler de sombrillas",
                            Zona = "Constitución"
                        },
                        new
                        {
                            Id = 2,
                            Accesos = "Transporte público cercano,Accesible para discapacitados",
                            Capacidad = 600,
                            Caracteristicas = "Agua limpia,Olas tranquilas,Arena blanca",
                            Direccion = "Avenida Central 456",
                            Imagenes = "assets/img/login.jpg,assets/img/recomendaciones.jpeg,assets/img/mar.jpg",
                            Nombre = "Punta Mogotes",
                            PromedioValoracion = 3.8m,
                            Servicios = "Parking cercano,Restaurantes,Alquiler de sombrillas",
                            Zona = "Zona Norte"
                        });
                });

            modelBuilder.Entity("tesisv2_back.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("usuario", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "user1@example.com",
                            FechaRegistro = new DateTime(2025, 1, 4, 20, 35, 25, 407, DateTimeKind.Utc).AddTicks(5245),
                            Nombre = "Usuario Uno",
                            UID = "12345"
                        });
                });

            modelBuilder.Entity("tesisv2_back.Models.Valoracion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ActividadId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Estrellas")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PlayaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActividadId");

                    b.HasIndex("PlayaId");

                    b.ToTable("Valoraciones");
                });

            modelBuilder.Entity("tesisv2_back.Models.Valoracion", b =>
                {
                    b.HasOne("tesisv2_back.Models.Actividad", "Actividad")
                        .WithMany("Valoraciones")
                        .HasForeignKey("ActividadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tesisv2_back.Models.Playa", "Playa")
                        .WithMany("Valoraciones")
                        .HasForeignKey("PlayaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actividad");

                    b.Navigation("Playa");
                });

            modelBuilder.Entity("tesisv2_back.Models.Actividad", b =>
                {
                    b.Navigation("Valoraciones");
                });

            modelBuilder.Entity("tesisv2_back.Models.Playa", b =>
                {
                    b.Navigation("Valoraciones");
                });
#pragma warning restore 612, 618
        }
    }
}
