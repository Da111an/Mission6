using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add MVC services for controllers and views
            builder.Services.AddControllersWithViews();

            // Configure Entity Framework Core with SQLite database
            builder.Services.AddDbContext<MovieContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("MovieConn"));
            });

            var app = builder.Build();

            // Configure error handling and security for production
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Enable HTTPS and static file serving
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Enable routing and authorization
            app.UseRouting();
            app.UseAuthorization();

            // Default route: Home controller, Index action
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}