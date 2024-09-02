using AutoMapper;
using BookStore.DTOs.Transaction;
using BookStore.Entities;
using BookStore.Repositories.TransactionRepository;

namespace BookStore.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        readonly ITransactionRepository _transactionRepository;
        readonly IMapper _mapper;
        public TransactionService(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }
        public async Task<decimal> BuyBookService(BuyBookTransactionDTO transaction)
        {
            var map = _mapper.Map<Transaction>(transaction);
            var data = await _transactionRepository.BuyBookRepository(map);
            if (data != -1)
            {
                return data;
            }
            return -1;
        }

        public async Task<decimal> FillBalanceService(decimal money, int userId)
        {
            var balance = await _transactionRepository.FillBalanceRepository(money, userId);
            if (balance == -1)
            {
                return -1;
            }
            return balance;
        }

        public async Task<IEnumerable<TransactionDTO>?> ViewBoughtBooksService(int userId)
        {
            var data = await _transactionRepository.ViewBoughtBooksRepository(userId);

            var map = _mapper.Map<IEnumerable<TransactionDTO>>(data);
            
            return map;
        }

        public async Task<decimal> ViewMyBalanceService(int userId)
        {
            var balance = await _transactionRepository.ViewMyBalanceRepository(userId);
            return balance;
        }
    }
}
