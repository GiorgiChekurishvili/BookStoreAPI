using BookStore.DTOs.Genre;
using BookStore.Entities;

namespace BookStore.Services.GenreService
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetGenres();
        Task<GenreDTO?> GetGenreById(int id);
        Task<string> InputGenres(string GenreName);
        Task<GenreDTO?> UpdateGenres(GenreDTO genre);
        Task DeleteGenre(int id);

    }
}
