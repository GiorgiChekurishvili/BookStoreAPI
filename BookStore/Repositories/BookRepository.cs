using BookStore.Data;
using BookStore.Entities;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        readonly BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateBook(Book book)
        {
            if (book.ReleaseDate < DateTime.Now)
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return book;
            }
            return null;
            
        }

        public async Task DeleteBook(int id)
        {
            var deletedbook = _context.Books.Find(id);
            if (deletedbook != null)
            {
                _context.Books.Remove(deletedbook);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var allBooks = await _context.Books
            .Include(x => x.Author!)
            .Include(x => x.Genres!)
            .ThenInclude(x => x.Genre)
            .Include(x => x.Publisher)
            .ToListAsync();
            return allBooks;

        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await _context.Books.Where(x=>x.Id == id).Include(x=>x.Author).Include(x=>x.Publisher).Include(x=>x.Genres!).ThenInclude(x=>x.Genre).FirstOrDefaultAsync();

            if (book != null)
            {
                return book;
            }
            return null;
        }

        public async Task UpdateBook(Book book)
        {
            if (book.ReleaseDate < DateTime.Now)
            {
                _context.Books.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
