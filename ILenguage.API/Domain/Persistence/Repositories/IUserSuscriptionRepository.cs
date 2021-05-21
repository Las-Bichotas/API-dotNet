using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IUserSuscriptionRepository
    {
        Task<IEnumerable<UserSubscription>> ListAsync();
        Task<IEnumerable<UserSubscription>> ListByUserId(int userId);
        Task<IEnumerable<UserSubscription>> ListBySuscriptionId(int suscriptionId);
        Task<IEnumerable<UserSubscription>> ListBySuscriptionIdAndUserId(int suscriptionId, int userId);
        Task AddAsync(UserSubscription userSubscription);
        void Remove(UserSubscription userSubscription);
        //? do i have to do by this wy? 
        Task AssingUserSuscription(int userId, int suscriptionId);
        Task UnassingUserSuscription(int userId, int SuscriptionId);
        
    }
}