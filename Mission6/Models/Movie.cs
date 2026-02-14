using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public partial class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; } // Primary Key

        [Required]
        public required string Category { get; set; } // Added 'required'

        [Required]
        public required string Title { get; set; } // Added 'required'

        [Required]
        public int Year { get; set; }

        [Required]
        public required string Director { get; set; } // Added 'required'

        [Required]
        public required string Rating { get; set; } // Added 'required'

        public bool? Edited { get; set; } // Optional (Nullable)

        public string? LentTo { get; set; } // Optional

        [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
        public string? Notes { get; set; } // Optional
    }
}