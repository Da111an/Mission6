using Microsoft.EntityFrameworkCore;

namespace Mission6.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        // You probably already have this one:
        public DbSet<Movie> Movies { get; set; }

        // ADD THIS LINE RIGHT HERE:
        public DbSet<Category> Categories { get; set; } 
    }
}