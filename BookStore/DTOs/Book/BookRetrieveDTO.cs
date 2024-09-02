using BookStore.Entities;

namespace BookStore.DTOs.Book
{
    public class BookRetrieveDTO
    {
        public int Id { get; set; }
        public required string BookName { get; set; }
        public required string Description { get; set; }
        public required List<string> GenreNames { get; set; }
        public required string AuthorName { get; set; }
        public decimal Price { get; set; }
        public required string Language { get; set; }
        public required string AgeRecommend { get; set; }
        public required string PublisherName { get; set; }
        public int StockQuantity { get; set; }
        public int StockLeft {  get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }

    }
}
