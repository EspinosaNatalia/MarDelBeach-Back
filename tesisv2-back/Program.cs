using Microsoft.EntityFrameworkCore;
using tesisv2_back.Data;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Configurar Firebase
var firebaseConfigPath = Path.Combine(Directory.GetCurrentDirectory(), "firebase-config.json");
FirebaseApp.Create(new AppOptions { Credential = GoogleCredential.FromFile(firebaseConfigPath) });

// Configurar políticas de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Dirección del Frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configurar el DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();

// Configuración de Swagger/OpenAPI (puedes eliminar esta sección si no usas Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Usar la política de CORS
app.UseCors("AllowAngularApp");

// Configure el pipeline de manejo de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
