using System.ComponentModel.DataAnnotations;

namespace BookStore.DTOs.Author
{
    public class AuthorRetrieveDTO
    {
        public int Id { get; set; }
        [Required]
        public string AuthorName { get; set; } = string.Empty;
        [Required]
        public string Biography { get; set; } = string.Empty;
        public required List<string> BooksWritten { get; set; }
        public string? DateOfBirth { get; set; }
        public string? DateOfDeath { get; set; }
    }
}
