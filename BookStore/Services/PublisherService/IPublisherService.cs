using BookStore.DTOs;

namespace BookStore.Services.PublisherService
{
    public interface IPublisherService
    {
        Task<IEnumerable<PublisherRetrieveDTO>> ViewAllPublishers();
        Task<PublisherRetrieveDTO> ViewPublisherById(int id);
        Task<PublisherDTO?> UploadPublisher(PublisherDTO publisher);
        Task<PublisherDTO?> UpdatePublisher(int id, PublisherDTO publisher);
        Task DeletePublisherService(int id);
    }
}
