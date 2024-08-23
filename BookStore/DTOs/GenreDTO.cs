using System.ComponentModel.DataAnnotations;

namespace BookStore.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
