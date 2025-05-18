using WebAPI_InventorySystem;
using WebAPI_InventorySystem.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_InventorySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 36))));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure HTTP request
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
