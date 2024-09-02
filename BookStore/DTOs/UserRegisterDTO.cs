using System.ComponentModel.DataAnnotations;

namespace BookStore.DTOs
{
    public class UserRegisterDTO
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
