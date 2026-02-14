using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // 1. Register the Database Context to use SQLite
            builder.Services.AddDbContext<MovieContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("MovieConn"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // 2. Ensure Static Files are enabled so your images in wwwroot/img work
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // 3. Simplified routing for Mission 6
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}