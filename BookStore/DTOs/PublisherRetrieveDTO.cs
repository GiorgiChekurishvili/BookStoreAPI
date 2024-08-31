using BookStore.Entities;

namespace BookStore.DTOs
{
    public class PublisherRetrieveDTO
    {
        public int Id { get; set; }
        public required string PublisherName { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Nationality { get; set; }
        public List<string>? BooksPublished { get; set; }
    }
}
