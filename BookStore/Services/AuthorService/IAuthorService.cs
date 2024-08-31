using BookStore.DTOs;

namespace BookStore.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorRetrieveDTO>> ViewAllAuthors();
        Task<AuthorRetrieveDTO> ViewAuthorById(int id);
        Task UploadAuthor(AuthorDTO author);
        Task UpdateAuthor(int id, AuthorDTO author);
        Task DeleteAuthorService(int id);
    }
}
