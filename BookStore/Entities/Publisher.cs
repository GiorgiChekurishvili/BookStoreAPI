namespace BookStore.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public required string PublisherName { get; set; }
        public  string? Address { get; set; } 
        public string? Website { get; set; }
        public string? PhoneNumber { get; set; } 
        public string? Nationality { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
