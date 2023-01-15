using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using TWT.Core.Repositories;
using TWT.Core.Repositories.Interfaces;
using TWT.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

namespace TWT.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("CarStore");
            Console.WriteLine(connectionString);
            builder.Services.AddDbContext<CarStoreDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.BuildServiceProvider().GetService<CarStoreDbContext>().Database.Migrate();

            builder.Services.AddScoped<ICarManagerRepository, CarManagerRepository>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            #region Configure Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Secret Key Auth", Version = "v1" });
                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}