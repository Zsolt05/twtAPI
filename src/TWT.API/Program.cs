using Microsoft.EntityFrameworkCore;
using TWT.Data;

namespace TWT.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("CarStore");
            builder.Services.AddDbContext<CarStoreDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            //builder.Services.BuildServiceProvider().GetService<CarStoreDbContext>().Database.Migrate();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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