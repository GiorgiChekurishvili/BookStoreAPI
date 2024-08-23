namespace BookStore.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public required string BookName { get; set; }
        public required string Description { get; set; }
        public int AuthorId { get; set; }
        public required Author Author { get; set; }
        public decimal Price { get; set; }
        public required string Language { get; set; }
        public required string AgeRecommend { get; set; }
        public int PublisherId { get; set; }
        public required Publisher Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }
        public int StockQuantity { get; set; }
        public ICollection<BookGenre>? Genres { get; set; }

    }
}
