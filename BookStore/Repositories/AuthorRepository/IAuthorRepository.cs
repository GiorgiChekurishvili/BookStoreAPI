using BookStore.Entities;

namespace BookStore.Repositories.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> RetrieveAllAuthors();
        Task<Author?> RetrieveAuthorById(int id);
        Task CreateAuthor(Author author);
        Task UpdateAuthor(Author author);
        Task DeleteAuthor(int id);
    }
}
