using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    /// <summary>
    /// Represents a movie category/genre (e.g., Action, Comedy, Drama).
    /// </summary>
    public class Category
    {
        // Primary key for the Category table
        [Key]
        public int CategoryId { get; set; }

        // Category name is required and must be unique
        public required string CategoryName { get; set; }
    }
}