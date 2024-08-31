using AutoMapper;
using BookStore.DTOs;
using BookStore.Entities;
using BookStore.Repositories.AuthorRepository;

namespace BookStore.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        readonly IMapper _mapper;
        readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task DeleteAuthorService(int id)
        {
            await _authorRepository.DeleteAuthor(id);
        }

        public async Task<AuthorDTO?> UpdateAuthor(int id, AuthorDTO author)
        {
            var map = _mapper.Map<Author>(author);
            map.Id = id;
            var data = await _authorRepository.UpdateAuthor(map);
            if (data == null)
            {
                return null;
            }
            return author;
        }

        public async Task<AuthorDTO?> UploadAuthor(AuthorDTO author)
        {
            var map = _mapper.Map<Author>(author);
            var data = await _authorRepository.CreateAuthor(map);
            if (data == null)
            {
                return null;
            }
            return author;


        }

        public async Task<IEnumerable<AuthorRetrieveDTO>> ViewAllAuthors()
        {
            var data = await _authorRepository.RetrieveAllAuthors();
            var map = _mapper.Map<IEnumerable<AuthorRetrieveDTO>>(data);
            return map;
        }

        public async Task<AuthorRetrieveDTO> ViewAuthorById(int id)
        {
            var data = await _authorRepository.RetrieveAuthorById(id);
            var map = _mapper.Map<AuthorRetrieveDTO>(data);
            return map;
        }
    }
}
