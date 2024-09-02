using BookStore.Data;
using BookStore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Repositories.TransactionRepository
{
    public class TransactionRepository : ITransactionRepository
    {
        readonly BookStoreContext _context;
        public TransactionRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<decimal> BuyBookRepository(Transaction transaction)
        {
            var ifexists = await _context.Books.FindAsync(transaction.BookId);
            if (ifexists == null)
            {
                return -1;
            }
            ifexists.StockLeft -= transaction.BoughtQuantity;
            if (ifexists.StockLeft < 0)
            {
                return -1;
            }
            var userbalance = await _context.Users.FindAsync(transaction.UserId);
            userbalance!.Balance -= (transaction.BoughtQuantity * ifexists.Price);
            if (userbalance.Balance < 0)
            {
                return -1;
            }
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            
            return transaction.BoughtQuantity * ifexists.Price;

        }

        public async Task<decimal> FillBalanceRepository(decimal money, int userId)
        {
            var data = await _context.Users.FindAsync(userId);
            data!.Balance += money;
            if (data.Balance < 0)
            {
                return -1;
            }
            await _context.SaveChangesAsync();
            return data.Balance;
        }

        public async Task<IEnumerable<Transaction>?> ViewBoughtBooksRepository(int UserId)
        {
            var data = await _context.Transactions.Include(x=>x.book).Where(x=>x.UserId == UserId).ToListAsync();
            if (data.Count == 0)
            {
                return null;
            }
            return data;
        }

        public async Task<decimal> ViewMyBalanceRepository(int userId)
        {
            var data = await _context.Users.FindAsync(userId);
            return data!.Balance;
        }
    }
}
