namespace BookStore.DTOs.Transaction
{
    public class TransactionDTO
    {
        public int BookId { get; set; }
        public required string BookName { get; set; }
        public int BoughtQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime BoughtDatetime { get; set; }
    }
}
