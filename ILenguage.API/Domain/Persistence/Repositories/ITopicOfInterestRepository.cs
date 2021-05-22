using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface ITopicOfInterestRepository
    {
        Task<IEnumerable<TopicsOfInterest>> ListAsync();
        Task AddAsync(TopicsOfInterest topicOf);
        Task<TopicsOfInterest> FindByIdAsync(int topicId);
        void Update(TopicsOfInterest topicOf);
        void Remove(TopicsOfInterest topicOf);
    }
}