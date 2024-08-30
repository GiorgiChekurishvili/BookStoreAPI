using BookStore.Entities;

namespace BookStore.Repositories.PublisherRepository
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> RetrieveAllPublishers();
        Task<Publisher> RetrievePublisherById (int id);
        Task<Publisher> CreatePublisher(Publisher publisher);
        Task<Publisher> UpdatePublisher(Publisher publisher);
        Task DeletePublisher(int id);
    }
}
