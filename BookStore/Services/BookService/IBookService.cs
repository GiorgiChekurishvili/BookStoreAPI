using BookStore.DTOs;

namespace BookStore.Services.BookService
{
    public interface IBookService
    {
        Task<IEnumerable<BookRetrieveDTO>> ViewAllBooks();
        Task<BookRetrieveDTO> ViewBookById(int id);
        Task<BookUploadUpdateDTO> UploadBook(BookUploadUpdateDTO bookUploadUpdateDTO);
        Task UpdateBook(int id, BookUploadUpdateDTO bookUploadUpdateDTO);
        Task DeleteBookService(int id);

    }
}
