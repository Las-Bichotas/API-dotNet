using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IUserSubscriptionRepository
    {
        Task<IEnumerable<UserSubscription>> ListAsync();
        Task<IEnumerable<UserSubscription>> ListByUserId(int userId);
        Task<IEnumerable<UserSubscription>> ListBySubscriptionId(int suscriptionId);
        Task<UserSubscription> FindBySubscriptionIdAndUserId(int userId, int subscriptionId);
        Task AddAsync(UserSubscription userSubscription);
        void Remove(UserSubscription userSubscription);
        //? do i have to do by this wy? 
        Task AssingUserSubscription(int userId, int subscriptionId);
        Task UnassingUserSubscription(int userId, int SuscriptionId);
        
        Task<UserSubscription> GetLastUserSubscriptionByUserIdAsync(int userId);

        
    }
}