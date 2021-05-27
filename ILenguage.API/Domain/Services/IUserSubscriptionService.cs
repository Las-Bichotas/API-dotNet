using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface IUserSubscriptionService
    {
        Task<IEnumerable<UserSubscription>> ListAsync();
        Task<IEnumerable<UserSubscription>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserSubscription>> ListBySubscriptionId(int suscriptionId);
        Task<UserSubscriptionResponse> AssingUserSubscriptionAsync(int userId, int subscriptionId);
        Task<UserSubscriptionResponse> UnassingUserSubscriptionAsync(int userId);

    }
}