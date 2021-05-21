using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class UserSubscriptionRepository : BaseRepository, IUserSubscriptionRepository
    {
        public UserSubscriptionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserSubscription>> ListAsync()
        {
        
            return await _context.UserSuscriptions.Include(us => us.Subscription)
                .Include(us => us.User)
                .ToListAsync();
            
        }

        public async Task<IEnumerable<UserSubscription>> ListByUserId(int userId)
        {
            return await _context.UserSuscriptions.Where(us => us.UserId == userId)
                .Include(us => us.Subscription)
                .Include(us => us.User)
                .ToListAsync();
        

        }

        public async Task<IEnumerable<UserSubscription>> ListBySubscriptionId(int suscriptionId)
        {
            return await _context.UserSuscriptions.Where(us => us.SubscriptionId == suscriptionId)
                .Include(us => us.Subscription)
                .Include(us => us.User)
                .ToListAsync();
           

        }

        public async Task<UserSubscription> FindBySubscriptionIdAndUserId(int suscriptionId, int userId)
        {
            return await _context.UserSuscriptions.FindAsync(userId, suscriptionId);
        }

        public async Task AddAsync(UserSubscription userSubscription)
        {
            await _context.UserSuscriptions.AddAsync(userSubscription);
        }

        public void Remove(UserSubscription userSubscription)
        {
            _context.UserSuscriptions.Remove(userSubscription);
        }

        public async Task AssingUserSubscription(int userId, int subscriptionId)
        {
            UserSubscription userSubscription = await FindBySubscriptionIdAndUserId(subscriptionId, userId);
            if (userSubscription == null)
            {
                userSubscription = new UserSubscription {UserId = userId, SubscriptionId = subscriptionId};
                await AddAsync(userSubscription);
            }
        }

        public async Task UnassingUserSubscription(int userId, int suscriptionId)
        {
            UserSubscription userSubscription = await FindBySubscriptionIdAndUserId(suscriptionId, userId);
            if (userSubscription != null)
                Remove(userSubscription);
        }
    }
}