
using Attendace_Std.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendace_Std
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("con"));
            });

            builder.Services.AddDistributedMemoryCache(); // ?????? ????? ??????? ??????? ?????? ???????
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1); // ????? ??? ?????? ?????? ??????
                options.Cookie.HttpOnly = true;  // ????? ?? ?????? ?? ???? ?????? ????? ??? JavaScript
                options.Cookie.IsEssential = true;  // ????? ?? ??????? ??????
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSession();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
