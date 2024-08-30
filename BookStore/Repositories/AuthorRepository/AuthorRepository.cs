using BookStore.Entities;

namespace BookStore.Repositories.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        public Task<Author> CreateAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> RetrieveAllAuthors()
        {
            throw new NotImplementedException();
        }

        public Task<Author> RetrieveAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Author> UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
