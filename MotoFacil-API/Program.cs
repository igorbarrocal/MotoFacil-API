using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MotoFacil_API.Data;
using MotoFacilAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura DbContext para Oracle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle")));

// Habilita CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // permite qualquer dom?nio (pode restringir depois)
              .AllowAnyMethod()   // permite GET, POST, PUT, DELETE
              .AllowAnyHeader();  // permite headers customizados
    });
});

builder.Services.AddControllers();

// Configura Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MotoF?cil API",
        Version = "v1",
        Description = "API para gerenciamento de usu?rios e motos no sistema MotoF?cil"
    });
});

var app = builder.Build();

// Habilita Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotoF?cil API v1");
    c.RoutePrefix = "swagger";
});

// Aplica CORS antes do MapControllers
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();
app.Run();
