using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class UserSuscriptionRepository : BaseRepository, IUserSuscriptionRepository
    {
        public UserSuscriptionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserSubscription>> ListAsync()
        {
            //? Is it important to list the PaymentMethod too? 
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

        public async Task<IEnumerable<UserSubscription>> ListBySuscriptionId(int suscriptionId)
        {
            return await _context.UserSuscriptions.Where(us => us.SuscriptionId == suscriptionId)
                .Include(us => us.Subscription)
                .Include(us => us.User)
                .ToListAsync();
           

        }

        public async Task<IEnumerable<UserSubscription>> ListBySuscriptionIdAndUserId(int suscriptionId, int userId)
        {
            return await _context.UserSuscriptions.Where(us => us.SuscriptionId == suscriptionId && us.UserId == userId)
                .Include(us => us.Subscription)
                .Include(us => us.User)
                .ToListAsync();
         
        }

        public async Task AddAsync(UserSubscription userSubscription)
        {
            await _context.UserSuscriptions.AddAsync(userSubscription);
        }

        public void Remove(UserSubscription userSubscription)
        {
            _context.UserSuscriptions.Remove(userSubscription);
        }

        public async Task AssingUserSuscription(int userId, int suscriptionId)
        {
           //TODO:
           await Task.Run(() => { });
           

        }

        public async Task UnassingUserSuscription(int userId, int SuscriptionId)
        {
            await Task.Run(() => { });
        }
    }
}