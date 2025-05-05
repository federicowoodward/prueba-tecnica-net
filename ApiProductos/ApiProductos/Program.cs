using ApiProductos.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar contexto de base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configurar el pipeline de la aplicación
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

// Ejecutar las migraciones cuando la aplicación arranque
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); // Aplica las migraciones automáticamente
}

// Configurar la URL de la API
app.Urls.Add("http://0.0.0.0:80");

// Arrancar la aplicación
app.Run();
