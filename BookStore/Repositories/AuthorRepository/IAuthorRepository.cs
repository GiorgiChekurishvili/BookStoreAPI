using BookStore.Entities;

namespace BookStore.Repositories.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> RetrieveAllAuthors();
        Task<Author?> RetrieveAuthorById(int id);
        Task<Author?> CreateAuthor(Author author);
        Task<Author?> UpdateAuthor(Author author);
        Task DeleteAuthor(int id);
    }
}
