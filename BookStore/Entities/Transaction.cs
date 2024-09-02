using Azure.Core.Pipeline;

namespace BookStore.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? user { get; set; }
        public int BookId { get; set; }
        public Book? book { get; set; }
        public int BoughtQuantity { get; set; }
        public DateTime BoughtDatetime { get; set; }
    }
}
