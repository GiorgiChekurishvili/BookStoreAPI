using AutoMapper;
using BookStore.DTOs;
using BookStore.Entities;
using BookStore.Repositories.GenreRepository;

namespace BookStore.Services.GenreService
{
    public class GenreService : IGenreService
    {
        readonly IGenreRepository _genreRepository;
        readonly IMapper _mapper;
        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }
        public async Task DeleteGenre(int id)
        {
            await _genreRepository.DeleteGenre(id);
        }

        public async Task<GenreDTO?> GetGenreById(int id)
        {
            var genreById = await _genreRepository.RetrieveGenreById(id);
            var map = _mapper.Map<GenreDTO>(genreById);
            return map;
        }

        public async Task<IEnumerable<GenreDTO>> GetGenres()
        {
            var genres = await _genreRepository.RetrieveGenres();
            var map = _mapper.Map<IEnumerable<GenreDTO>>(genres);
            return map;
        }

        public async Task<string> InputGenres(string GenreName)
        {
            
            var inputGenre = await _genreRepository.CreateGenres(GenreName);
            return inputGenre.GenreName;
        }

        public async Task<GenreDTO?> UpdateGenres(GenreDTO genre)
        {
            var map = _mapper.Map<Genre>(genre);
            var data = await _genreRepository.UpdateGenres(map);
            if (data == null)
            {
                return null;
            }
            var mapdata = _mapper.Map<GenreDTO>(data);
            return mapdata;
        }
    }
}
