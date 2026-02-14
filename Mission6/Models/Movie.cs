using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public partial class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; } // Primary Key

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; } // Will be a dropdown in the View

        public bool? Edited { get; set; } // Optional (Nullable)

        public string? LentTo { get; set; } // Optional

        [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
        public string? Notes { get; set; } // Optional
    }
}