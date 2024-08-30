using BookStore.Entities;

namespace BookStore.Repositories.PublisherRepository
{
    public class PublisherRepository : IPublisherRepository
    {
        public Task<Publisher> CreatePublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public Task DeletePublisher(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Publisher>> RetrieveAllPublishers()
        {
            throw new NotImplementedException();
        }

        public Task<Publisher> RetrievePublisherById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Publisher> UpdatePublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }
    }
}
