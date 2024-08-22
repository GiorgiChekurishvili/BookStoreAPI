using System.ComponentModel.DataAnnotations;

namespace BookStore.DTOs
{
    public class AuthorDTO
    {
        [Required]
        public  string AuthorName { get; set; } = string.Empty;
        [Required]
        public string Biography { get; set; } = string.Empty;
        public  string? DateOfBirth { get; set; }

        public  string? DateOfDeath { get; set; }
    }
}
