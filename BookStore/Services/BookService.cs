using AutoMapper;
using BookStore.DTOs;
using BookStore.Entities;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        readonly IBookRepository _bookRepository;
        readonly IMapper _mapper;
        readonly IBookGenresRepository _bookGenresRepository;
        public BookService(IBookRepository bookRepository, IMapper mapper, IBookGenresRepository bookGenresRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _bookGenresRepository = bookGenresRepository;
        }
        public async Task DeleteBookService(int id)
        {
            await _bookRepository.DeleteBook(id);
        }

        public async Task UpdateBook(int id, BookUploadUpdateDTO bookUploadUpdateDTO)
        {
            var map = _mapper.Map<Book>(bookUploadUpdateDTO);
            map.Id = id;
            var updatedbook = await _bookRepository.UpdateBook(map);
            if (updatedbook != null)
            {
                await _bookGenresRepository.UpdateBookGenres(bookUploadUpdateDTO.GenreIds, updatedbook.Id);
            }
        }

        public async Task<BookUploadUpdateDTO> UploadBook(BookUploadUpdateDTO bookUploadUpdateDTO)
        {
            var map =  _mapper.Map<Book>(bookUploadUpdateDTO);
            var books = await  _bookRepository.CreateBook(map);
            if (books != null)
            {
                await _bookGenresRepository.UploadBookGenres(bookUploadUpdateDTO.GenreIds!, books.Id);
                return bookUploadUpdateDTO;
            }
            return null;
        }

        public async Task<IEnumerable<BookRetrieveDTO>> ViewAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            var map = _mapper.Map<IEnumerable<BookRetrieveDTO>>(books);
            return map;
        }

        public async Task<BookRetrieveDTO> ViewBookById(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            var map = _mapper.Map<BookRetrieveDTO>(book);
            return map;
        }
    }
}
