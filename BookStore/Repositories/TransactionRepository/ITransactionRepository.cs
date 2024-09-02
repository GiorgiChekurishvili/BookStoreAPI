using BookStore.Entities;

namespace BookStore.Repositories.TransactionRepository
{
    public interface ITransactionRepository
    {
        Task<decimal> FillBalanceRepository(decimal money, int userId);
        Task<decimal> ViewMyBalanceRepository(int userId);
        Task<decimal> BuyBookRepository(Transaction transaction);
        Task<IEnumerable<Transaction>?> ViewBoughtBooksRepository(int userId);
    }
}
