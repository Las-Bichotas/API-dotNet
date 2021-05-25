using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface IUserTopicService
    {
        Task<IEnumerable<UserTopics>> ListAsync();
        Task<IEnumerable<UserTopics>> ListByUserId(int userId);
        Task<IEnumerable<UserTopics>> ListByTopicId(int topicId);
        Task<UserTopicsResponse> AssignTopicUser(int userId, int topicId);
        Task<UserTopicsResponse> UnassignTopicUser(int userId, int topicId);
    }
}