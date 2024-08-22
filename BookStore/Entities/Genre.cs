namespace BookStore.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public required string GenreName { get; set; }

        public  ICollection<BookGenre>? Books { get; set; }
    }
}
