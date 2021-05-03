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

        public async Task<IEnumerable<UserSuscription>> ListAsync()
        {
            //? Is it important to list the PaymentMethod too? 
            return await _context.UserSuscriptions.Include(us => us.Suscription)
                .Include(us => us.User)
                .ToListAsync();
            
        }

        public async Task<IEnumerable<UserSuscription>> ListByUserId(int userId)
        {
            return await _context.UserSuscriptions.Where(us => us.UserId == userId)
                .Include(us => us.Suscription)
                .Include(us => us.User)
                .ToListAsync();
        

        }

        public async Task<IEnumerable<UserSuscription>> ListBySuscriptionId(int suscriptionId)
        {
            return await _context.UserSuscriptions.Where(us => us.SuscriptionId == suscriptionId)
                .Include(us => us.Suscription)
                .Include(us => us.User)
                .ToListAsync();
           

        }

        public async Task<IEnumerable<UserSuscription>> ListBySuscriptionIdAndUserId(int suscriptionId, int userId)
        {
            return await _context.UserSuscriptions.Where(us => us.SuscriptionId == suscriptionId && us.UserId == userId)
                .Include(us => us.Suscription)
                .Include(us => us.User)
                .ToListAsync();
         
        }

        public async Task AddAsync(UserSuscription userSuscription)
        {
            await _context.UserSuscriptions.AddAsync(userSuscription);
        }

        public void Remove(UserSuscription userSuscription)
        {
            _context.UserSuscriptions.Remove(userSuscription);
        }

        public async Task AssingUserSuscription(int userId, int suscriptionId)
        {
           //TODO:
           throw new System.NotImplementedException();

        }

        public async Task UnassingUserSuscription(int userId, int SuscriptionId)
        {
            throw new System.NotImplementedException();
        }
    }
}