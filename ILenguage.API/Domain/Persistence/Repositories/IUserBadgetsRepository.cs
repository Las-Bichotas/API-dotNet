using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IUserBadgetsRepository
    {
        Task<IEnumerable<UserBadgets>> ListAsync();
        Task<IEnumerable<UserBadgets>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserBadgets>> ListByBadgetIdAsync(int badgetId);
        Task AssignBadgetUser(int userId, int badgetId);
        Task UnassignBadgetUser(int userId, int badgetId);
        Task<UserBadgets> FindByUserIdAndBadgetId(int userId, int BadgetId);
        void Remove(UserBadgets userBadgets);
        Task AddAsync(UserBadgets userBadgets);
    }
}