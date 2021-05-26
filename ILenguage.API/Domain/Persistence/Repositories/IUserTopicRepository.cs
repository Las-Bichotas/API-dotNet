using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IUserTopicRepository
    {
        Task<IEnumerable<UserTopics>> ListAsync();
        Task<IEnumerable<UserTopics>> ListByUserId(int userId);
        Task<IEnumerable<UserTopics>> ListByTopicId(int topicId);
        Task AssignTopicUser(int userId, int topicId);
        Task UnassignTopicUser(int userId, int topicId);
        Task<UserTopics> FindByUserIdAndTopicId(int userId, int topicId);
        void Remove(UserTopics userTopics);
        Task AddAsync(UserTopics userTopics);
    }
}