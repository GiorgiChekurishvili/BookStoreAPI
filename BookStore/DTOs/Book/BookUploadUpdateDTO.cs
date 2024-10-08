﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.DTOs.Book
{
    public class BookUploadUpdateDTO
    {
        [Required]
        public string BookName { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public List<int>? GenreIds { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [Required]
        public string Language { get; set; } = string.Empty;
        [Required]
        public string AgeRecommend { get; set; } = string.Empty;
        [Required]
        public int StockQuantity { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
