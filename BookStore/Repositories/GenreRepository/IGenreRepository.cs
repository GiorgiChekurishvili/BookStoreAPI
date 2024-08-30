using BookStore.DTOs;
using BookStore.Entities;

namespace BookStore.Repositories.GenreRepository
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> RetrieveGenres();
        Task<Genre?> RetrieveGenreById(int id);
        Task<Genre?> CreateGenres(string genreName);
        Task<Genre?> UpdateGenres(Genre genre);
        Task DeleteGenre(int id);


    }
}
