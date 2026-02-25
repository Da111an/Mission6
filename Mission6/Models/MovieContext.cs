using Microsoft.EntityFrameworkCore;

namespace Mission6.Models
{
    /// <summary>
    /// Entity Framework Core database context for the Movie database.
    /// Manages connections to Movies and Categories tables.
    /// </summary>
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        // Database tables
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}