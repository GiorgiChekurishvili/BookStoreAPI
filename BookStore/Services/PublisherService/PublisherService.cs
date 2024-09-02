using AutoMapper;
using BookStore.DTOs.Publisher;
using BookStore.Entities;
using BookStore.Repositories.PublisherRepository;

namespace BookStore.Services.PublisherService
{
    public class PublisherService : IPublisherService
    {
        readonly IPublisherRepository _publisherRepository;
        readonly IMapper _mapper;
        public PublisherService(IMapper mapper, IPublisherRepository publisherRepository)
        {
            _mapper = mapper;
            _publisherRepository = publisherRepository;
        }
        public async Task DeletePublisherService(int id)
        {
           await _publisherRepository.DeletePublisher(id);
        }

        public async Task<PublisherDTO?> UpdatePublisher(int id, PublisherDTO publisher)
        {
            var map = _mapper.Map<Publisher>(publisher);
            map.Id = id;
            var data = await _publisherRepository.UpdatePublisher(map);
            if (data == null)
            {
                return null;
            }
            return publisher;
        }

        public async Task<PublisherDTO?> UploadPublisher(PublisherDTO publisher)
        {
            var map = _mapper.Map<Publisher>(publisher);
            var data = await _publisherRepository.CreatePublisher(map);
            if (data == null)
            {
                return null;
            }
            return publisher;
        }

        public async Task<IEnumerable<PublisherRetrieveDTO>> ViewAllPublishers()
        {
            var data = await _publisherRepository.RetrieveAllPublishers();
            var map = _mapper.Map<IEnumerable<PublisherRetrieveDTO>>(data);
            return map;
        }

        public async Task<PublisherRetrieveDTO> ViewPublisherById(int id)
        {
            var data = await _publisherRepository.RetrievePublisherById(id);
            var map = _mapper.Map<PublisherRetrieveDTO>(data);
            return map;

        }
    }
}
