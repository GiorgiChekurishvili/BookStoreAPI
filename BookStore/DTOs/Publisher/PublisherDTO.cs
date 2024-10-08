﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.DTOs.Publisher
{
    public class PublisherDTO
    {
        [Required]
        public string PublisherName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Website { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Nationality { get; set; }
    }
}
