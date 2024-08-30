using System.ComponentModel.DataAnnotations;

namespace BookStore.DTOs
{
    public class GenreDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string GenreName { get; set; } = string.Empty;
    }
}
