using BookStore.Data;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace BookStore.Repositories.GenreRepository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly BookStoreContext _context;
        public GenreRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task DeleteGenre(int id)
        {
            var genreRemove = await _context.Genres.FindAsync(id);
            if (genreRemove != null)
            {
                _context.Genres.Remove(genreRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Genre?> RetrieveGenreById(int id)
        {
            var bookById = await _context.Genres.FindAsync(id);
            if (bookById != null)
                return bookById;

            return null;
          
        }

        public async Task<IEnumerable<Genre>> RetrieveGenres()
        {
            var allBooks = await _context.Genres.ToListAsync();
            return allBooks;
            
        }

        public async Task<Genre?> CreateGenres(string genreName)
        {
            var genreCheck = await _context.Genres.Where(x=>x.GenreName.ToUpper() ==  genreName.ToUpper()).FirstOrDefaultAsync();
            if (genreCheck == null)
            {
                var genre = new Genre() { GenreName = genreName };
                await _context.Genres.AddAsync(genre);
                await _context.SaveChangesAsync();
                return genre;
            }
            return null;
        }

        public async Task<Genre?> UpdateGenres(Genre genre)
        {
            var genreCheck = await _context.Genres.Where(x => x.GenreName.ToUpper() == genre.GenreName.ToUpper()).FirstOrDefaultAsync();
            if (genreCheck == null)
            {
                _context.Genres.Entry(genre).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return genre;
            }
            return null;
        }
    }
}
