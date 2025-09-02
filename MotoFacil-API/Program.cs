using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MotoFacilAPI.Infrastructure.Persistence;
using MotoFacilAPI.Domain.Repositories;
using MotoFacilAPI.Infrastructure.Repositories;
using MotoFacilAPI.Application.Interfaces;
using MotoFacilAPI.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// DbContext (Oracle) - expects connection string "Oracle" in appsettings
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle")));

// Dependency Injection - Repositories
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IMotoRepository, MotoRepository>();
builder.Services.AddScoped<IServicoRepository, ServicoRepository>();

// Dependency Injection - Services (Application)
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IMotoService, MotoService>();
builder.Services.AddScoped<IServicoService, ServicoService>();

// Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Serialize enums as strings (optional)
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

// CORS (allow any for local dev; tighten in prod)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MotoFacil API",
        Version = "v1",
        Description = "API para gerenciamento de usuários, motos e serviços no sistema MotoFácil"
    });
});

var app = builder.Build();

// Middleware
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotoFacil API v1");
    c.RoutePrefix = string.Empty; // Swagger na raiz
});

app.MapControllers();

app.Run();