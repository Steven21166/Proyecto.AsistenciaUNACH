using Microsoft.EntityFrameworkCore;
using Proyecto.AsistenciaUNACH.Persistencia.Models;
using Proyecto.AsistenciaUNACH.Persistencia.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AsistenciaUNACHContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AsistenciaUNACH")
    )
);

//llama a repositorios en persistencia 
builder.Services.AddScoped<ICarreraRepositorio, CarreraRepositorio>();
builder.Services.AddScoped<IAsignaturaRepositorio, AsignaturaRepositorio>();
builder.Services.AddScoped<IDocenteRepositorio, DocenteRepositorio>();
builder.Services.AddScoped<IEstudianteRepositorio, EstudianteRepositorio>();
builder.Services.AddScoped<IAsistenciaEstudianteRepositorio, AsistenciaEstudianteRepositorio>();
builder.Services.AddScoped<IDetalleMatriculaRepositorio, DetalleMatriculaRepositorio>();
builder.Services.AddScoped<IDocenteAsignaturaRepositorio, DocenteAsignaturaRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
