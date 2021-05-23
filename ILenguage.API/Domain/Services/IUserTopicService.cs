using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services
{
    public interface IUserTopicService
    {
        Task<IEnumerable<UserTopics>> ListAsync();
        Task<IEnumerable<UserTopics>> ListByUserId(int userId);
        Task AssignTopicUser(int userId, int topicId);
        Task UnassignTopicUser(int userId, int topicId);
    }
}