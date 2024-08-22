using BookStore.Entities;

namespace BookStore.Repositories
{
    public interface IBookRepository
    {
         Task<IEnumerable<Book>> GetAllBooks();
         Task<Book> GetBookById(int id);
         Task<Book> CreateBook(Book book);
         Task UpdateBook(Book book);
         Task DeleteBook(int id);
    }
}
