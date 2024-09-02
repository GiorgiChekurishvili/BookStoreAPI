namespace BookStore.DTOs.Transaction
{
    public class BuyBookTransactionDTO
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int BoughtQuantity { get; set; }
    }
}
