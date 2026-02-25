using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models
{
    /// <summary>
    /// Represents a movie in the collection.
    /// Director and Rating are optional fields to allow flexibility in data entry.
    /// </summary>
    public partial class Movie
    {
        // Primary key for the Movie table
        [Key]
        public int MovieId { get; set; }

        // Foreign key reference to Category (required)
        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        // Navigation property to associated Category
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        // Required basic information about the movie
        [Required]
        public string? Title { get; set; }

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        // Optional fields for additional details
        public string? Director { get; set; }
        public string? Rating { get; set; }

        // Tracks movie editing status and Plex library synchronization
        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }

        // Notes field limited to 25 characters for concise comments
        [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
        public string? Notes { get; set; }
    }
}