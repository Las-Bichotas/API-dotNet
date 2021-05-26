using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class UserTopicsRepository : BaseRepository, IUserTopicRepository
    {
        public UserTopicsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(UserTopics userTopics)
        {
            await _context.UserTopics.AddAsync(userTopics);
        }
        public async Task AssignTopicUser(int userId, int topicId)
        {
            UserTopics userTopics = await FindByUserIdAndTopicId(userId, topicId);
            if (userTopics == null)
            {
                userTopics = new UserTopics { UserId = userId, TopicId = topicId };
                await AddAsync(userTopics);
            }
        }

        public async Task<UserTopics> FindByUserIdAndTopicId(int userId, int topicId)
        {
            return await _context.UserTopics.FindAsync(userId, topicId);
        }

        public async Task<IEnumerable<UserTopics>> ListAsync()
        {
            return await _context.UserTopics
                .Include(ut => ut.User)
                .Include(ut => ut.Topic)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserTopics>> ListByTopicId(int topicId)
        {
            return await _context.UserTopics
                .Where(ut => ut.TopicId == topicId)
                .Include(ut => ut.User)
                .Include(ut => ut.Topic)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserTopics>> ListByUserId(int userId)
        {
            return await _context.UserTopics
                .Where(ut => ut.UserId == userId)
                .Include(ut => ut.User)
                .Include(ut => ut.Topic)
                .ToListAsync();
        }

        public void Remove(UserTopics userTopics)
        {
            _context.UserTopics.Remove(userTopics);
        }

        public async Task UnassignTopicUser(int userId, int topicId)
        {
            UserTopics userTopics = await FindByUserIdAndTopicId(userId, topicId);
            if (userTopics != null)
                Remove(userTopics);
        }
    }
}