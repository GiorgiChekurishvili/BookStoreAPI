using BookStore.Data;
using BookStore.Entities;

namespace BookStore.Repositories.GenreRepository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly BookStoreContext _context;
        public GenreRepository(BookStoreContext context)
        {
            _context = context;
        }

        public Task DeleteGenre(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetGenreById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetGenres()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> InputGenres(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGenres(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
