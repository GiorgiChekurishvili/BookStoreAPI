using BookStore.Data;
using BookStore.DTOs;
using BookStore.Entities;
using System.Reflection.Metadata.Ecma335;

namespace BookStore.Repositories.BookGenresRepository
{
    public class BookGenresRepository : IBookGenresRepository
    {
        private readonly BookStoreContext _context;
        public BookGenresRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task UpdateBookGenres(List<int> ids, int bookId)
        {
            var bookRetrieve = await _context.BookGenres.Where(x => x.BookId == bookId).ToListAsync();

            var genresToAdd = ids.Except(bookRetrieve.Select(bg => bg.GenreId)).ToList();
            var genresToRemove = bookRetrieve.Where(bg => !ids.Contains(bg.GenreId)).ToList();

            foreach (var genreId in genresToAdd)
            {
                var newBookGenre = new BookGenre
                {
                    BookId = bookId,
                    GenreId = genreId
                };
                _context.BookGenres.Add(newBookGenre);
            }

            foreach (var bookGenre in genresToRemove)
            {
                _context.BookGenres.Remove(bookGenre);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UploadBookGenres(List<int> ids, int bookId)
        {
            var bookGenres = new List<BookGenre>();

            foreach (var genreId in ids)
            {
                var bookGenre = new BookGenre
                {
                    BookId = bookId,
                    GenreId = genreId
                };
                bookGenres.Add(bookGenre);
            }

            await _context.BookGenres.AddRangeAsync(bookGenres);
            await _context.SaveChangesAsync();
        }
    }
}
