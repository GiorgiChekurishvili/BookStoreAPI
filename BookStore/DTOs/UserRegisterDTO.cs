﻿namespace BookStore.DTOs
{
    public class UserRegisterDTO
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
