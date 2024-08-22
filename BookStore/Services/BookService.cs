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
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task DeleteBookService(int id)
        {
            await _bookRepository.DeleteBook(id);
        }

        public async Task UpdateBook(int id, BookUploadUpdateDTO bookUploadUpdateDTO)
        {
            var map = _mapper.Map<Book>(bookUploadUpdateDTO);
            map.Id = id;
            await _bookRepository.UpdateBook(map);

        }

        public async Task<BookUploadUpdateDTO> UploadBook(BookUploadUpdateDTO bookUploadUpdateDTO)
        {
            var map =  _mapper.Map<Book>(bookUploadUpdateDTO);
            var books = await  _bookRepository.CreateBook(map);
            if (books != null)
            {
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
