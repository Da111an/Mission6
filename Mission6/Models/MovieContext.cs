using Microsoft.EntityFrameworkCore;
using Mission06.Models;
using System.Collections.Generic;

namespace Mission6.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}