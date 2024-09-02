

using BookStore.DTOs.Transaction;

namespace BookStore.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<decimal> FillBalanceService(decimal money, int userId);
        Task<decimal> ViewMyBalanceService(int userId);
        Task<decimal> BuyBookService(BuyBookTransactionDTO transaction);
        Task<IEnumerable<TransactionDTO>?> ViewBoughtBooksService(int userId);
    }
}
