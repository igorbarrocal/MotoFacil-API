using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MotoFacilAPI.Infrastructure.Persistence;
using MotoFacilAPI.Domain.Repositories;
using MotoFacilAPI.Infrastructure.Repositories;
using MotoFacilAPI.Application.Interfaces;
using MotoFacilAPI.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Conexão Oracle definida em appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle")));

// Injeção de dependência dos repositórios (Domain/Infra)
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IMotoRepository, MotoRepository>();
builder.Services.AddScoped<IServicoRepository, ServicoRepository>();

// Injeção de dependência dos serviços de aplicação (Application)
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IMotoService, MotoService>();
builder.Services.AddScoped<IServicoService, ServicoService>();

// Controllers + Enum como string no JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

// CORS liberado para dev
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Configuração Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MotoFacil API",
        Version = "v1",
        Description = "API para gerenciamento de usuários, motos e serviços no sistema MotoFácil"
    });
    // Mostra exemplos e modelos (se anotados nos DTOs)
    c.EnableAnnotations();
});

// Pipeline
var app = builder.Build();

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotoFacil API v1");
    c.RoutePrefix = string.Empty; // Swagger na raiz
});

app.MapControllers();

app.Run();