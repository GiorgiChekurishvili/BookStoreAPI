using BookStore.Entities;

namespace BookStore.Repositories.BookRepository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book?> GetBookById(int id);
        Task<Book?> CreateBook(Book book);
        Task<Book?> UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}
