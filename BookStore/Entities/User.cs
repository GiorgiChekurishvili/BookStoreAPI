﻿namespace BookStore.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public required string Email { get; set; }
        public  byte[]? PasswordHash { get; set; }
        public  byte[]? PasswordSalt { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
