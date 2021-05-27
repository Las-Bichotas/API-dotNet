using System;
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

        public async Task<UserSubscription> FindBySubscriptionIdAndUserId(int userId, int subscriptionId)
        {
            return await _context.UserSuscriptions
                .Include(sub=> sub.User)
                .Include(sub => sub.Subscription)
                .FirstOrDefaultAsync(us => us.UserId == userId && us.SubscriptionId == subscriptionId);
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
            //UserSubscription userSubscription = await FindBySubscriptionIdAndUserId(userId, subscriptionId);
           // if (userSubscription == null)
           // {
                Subscription foundSubscription = await _context.Subscriptions.FindAsync(subscriptionId);
                
                var userSubscription = new UserSubscription {UserId = userId, SubscriptionId = subscriptionId};
                userSubscription.InitialDate = DateTime.Now;
                userSubscription.FinalDate =
                    userSubscription.InitialDate.AddMonths(foundSubscription.MonthDuration);

                await AddAsync(userSubscription);
           // }
        }

        public async Task UnassingUserSubscription(int userId)
        {
            var existingUserSubscription = await GetLastUserSubscriptionByUserIdAsync(userId);
            existingUserSubscription.FinalDate = DateTime.Now;
            _context.Update(existingUserSubscription);
            _context.SaveChanges();
        }

        public async Task<UserSubscription> GetLastUserSubscriptionByUserIdAsync(int userId)
        {
            var userSubscription = await _context.UserSuscriptions
                .Where(u => u.UserId == userId)
                .OrderByDescending(u => u.FinalDate)
                .FirstOrDefaultAsync();
            return userSubscription;
        }
    }
}