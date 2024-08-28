namespace BookStore.Repositories.BookGenresRepository
{
    public interface IBookGenresRepository
    {
        Task UploadBookGenres(List<int> ids, int bookId);
        Task UpdateBookGenres(List<int> ids, int bookId);
    }
}
