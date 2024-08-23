
using BookStore.Data;
using BookStore.DTOs;
using BookStore.Entities;
using System.Reflection.Metadata.Ecma335;

namespace BookStore.Repositories
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
            var bookGenres = new List<BookGenre>();
            var bookRetrieve = await _context.BookGenres.Where(x=>x.BookId == bookId).ToListAsync();
            foreach (var genreId in ids) 
            {
                var bookGenre = new BookGenre
                {
                    BookId = bookId,
                    GenreId = genreId
                };
                bookGenres.Add(bookGenre);
            }
            if (bookGenres.Count < bookRetrieve.Count)
            {
                for (int i = 0; i < bookRetrieve.Count; i++)
                {

                    if (!bookGenres.Any(x => x.GenreId == bookRetrieve[i].GenreId))
                    {
                        var bookGenreRemove = await _context.BookGenres.Where(x => x.BookId == bookId && x.GenreId == bookRetrieve[i].GenreId).FirstOrDefaultAsync();
                        if (bookGenreRemove != null)
                        {
                            _context.BookGenres.Remove(bookGenreRemove);
                            await _context.SaveChangesAsync();
                        }

                    }
                

                }
            }
            if (bookGenres.Count > bookRetrieve.Count)
            {
                List<int> bookIdAdded = new List<int>();
                for (int i = 0; i < bookGenres.Count; i++)
                {
                    if (!bookRetrieve.Any(x => x.GenreId == bookGenres[i].GenreId))
                    {
                        bookIdAdded.Add(bookGenres[i].GenreId);
                    }
                }
                await UploadBookGenres(bookIdAdded, bookId);
                

            }
            for (int i = 0; i < bookGenres.Count; i++)
            {
                if (bookGenres[i].GenreId != bookRetrieve[i].GenreId)
                {
                    var updatedBook = await _context.BookGenres.Where(x => x.BookId == bookRetrieve[i].BookId && x.GenreId == bookRetrieve[i].GenreId).FirstOrDefaultAsync();
                    if (updatedBook != null)
                    {
                        bookGenres[i].Id = updatedBook.Id;
                        _context.BookGenres.Entry(bookGenres[i]).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }

                }
            }
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
