using BookStore.Data;
using BookStore.Entities;

namespace BookStore.Repositories.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        readonly BookStoreContext _context;
        public AuthorRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task CreateAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthor(int id)
        {
            var data = await _context.Authors.FindAsync(id);
            if (data != null)
            {

                _context.Authors.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Author>> RetrieveAllAuthors()
        {
            var data = await _context.Authors.Include(x=>x.Books).ToListAsync();
            return data;
        }

        public async Task<Author?> RetrieveAuthorById(int id)
        {
            var data = await _context.Authors.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {

                return data;
            }
            return null;
        }

        public async Task UpdateAuthor(Author author)
        {
            _context.Authors.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
