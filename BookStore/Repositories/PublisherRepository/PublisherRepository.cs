using BookStore.Data;
using BookStore.Entities;

namespace BookStore.Repositories.PublisherRepository
{
    public class PublisherRepository : IPublisherRepository
    {
        readonly BookStoreContext _context;
        public PublisherRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<Publisher?> CreatePublisher(Publisher publisher)
        {
            var ifExists = await _context.Publishers.Where(x=>x.PublisherName.ToUpper() ==  publisher.PublisherName.ToUpper()).FirstOrDefaultAsync();
            if (ifExists == null)
            {
                await _context.Publishers.AddAsync(publisher);
                await _context.SaveChangesAsync();
                return publisher;
            }
            return null;
        }

        public async Task DeletePublisher(int id)
        {
            var data = await _context.Publishers.FindAsync(id);
            if (data != null)
            {
                _context.Publishers.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Publisher>> RetrieveAllPublishers()
        {
            var data = await _context.Publishers.Include(x=>x.Books).ToListAsync();
            return data;
        }

        public async Task<Publisher?> RetrievePublisherById(int id)
        {
            var data = await _context.Publishers.Include(x=>x.Books).Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Publisher?> UpdatePublisher(Publisher publisher)
        {
            var ifexists = await _context.Publishers.Where(x=>x.PublisherName.ToUpper() == publisher.PublisherName.ToUpper()).FirstOrDefaultAsync();
            if (ifexists == null)
            {
                _context.Publishers.Entry(publisher).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return publisher;
            }
            return null;
        }
    }
}
