
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class TopicOfInterestRepository : BaseRepository, ITopicOfInterestRepository
    {
        public TopicOfInterestRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(TopicsOfInterest topicOf)
        {
            await _context.TopicsOfInterests.AddAsync(topicOf);
        }

        public async Task<TopicsOfInterest> FindByIdAsync(int topicId)
        {
            return await _context.TopicsOfInterests.FindAsync(topicId);
        }

        public async Task<IEnumerable<TopicsOfInterest>> ListAsync()
        {
            return await _context.TopicsOfInterests.ToListAsync();
        }

        public void Remove(TopicsOfInterest topicOf)
        {
            _context.TopicsOfInterests.Remove(topicOf);
        }

        public void Update(TopicsOfInterest topicOf)
        {
            _context.TopicsOfInterests.Update(topicOf);
        }
    }
}