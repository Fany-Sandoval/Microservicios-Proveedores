using Microservicios.Infraestructura;
using Microservicios.Persistencia;
using Microservicios.Proveedor.Aplicacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microservicios.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<ProveedoresContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        // Configurar la conexión a SQL Server
        builder.Services.AddScoped<IProvedorRepository, ProveedorRepository>();
        builder.Services.AddScoped<ProveedorService>();
        // Registrar MediatR
        builder.Services.AddMediatR(typeof(Consulta.Manejador).Assembly);
        builder.Services.AddControllers();

        // Agregar CORS
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(option =>
        {
            option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
            {
                Name = "Autorization",
                Description = "Ingresa el token de autorización de Bearer ejemplo: Bearer Generated-JWT-Token",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            new string[]{ }
            }
            });
        });
        builder.AddAppAuthentication();
        builder.Services.AddAuthentication();
        

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        // Habilitar CORS
        app.UseCors();
        app.UseAuthentication();
        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();

       
        app.Run();
    }
}

