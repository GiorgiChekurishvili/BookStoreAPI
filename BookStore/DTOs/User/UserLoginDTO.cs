using System.ComponentModel.DataAnnotations;

namespace BookStore.DTOs.User
{
    public class UserLoginDTO
    {
        [EmailAddress, Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
