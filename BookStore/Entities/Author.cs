namespace BookStore.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public required string AuthorName { get; set; }
        public required string Biography { get; set; }
        public string? DateOfBirth { get; set; }
        public string? DateOfDeath { get; set; }

        public  ICollection<Book>? Books { get; set;}
    }
}
