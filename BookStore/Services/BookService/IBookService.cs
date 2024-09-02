using BookStore.DTOs.Book;

namespace BookStore.Services.BookService
{
    public interface IBookService
    {
        Task<IEnumerable<BookRetrieveDTO>> ViewAllBooks();
        Task<BookRetrieveDTO> ViewBookById(int id);
        Task<BookUploadUpdateDTO?> UploadBook(BookUploadUpdateDTO bookUploadUpdateDTO);
        Task<BookUploadUpdateDTO?> UpdateBook(int id, BookUploadUpdateDTO bookUploadUpdateDTO);
        Task DeleteBookService(int id);

    }
}
