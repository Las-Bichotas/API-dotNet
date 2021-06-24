using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class UserBadgetsRespository : BaseRepository, IUserBadgetsRepository
    {
        public UserBadgetsRespository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(UserBadgets userBadgets)
        {
            await _context.UserBadgets.AddAsync(userBadgets);
        }

        public async Task AssignBadgetUser(int userId, int badgetId)
        {
            UserBadgets userBadgets = await FindByUserIdAndBadgetId(userId, badgetId);
            if (userBadgets == null)
            {
                userBadgets = new UserBadgets { UserId = userId, BadgetId = badgetId };
                await AddAsync(userBadgets);
            }
        }

        public async Task<UserBadgets> FindByUserIdAndBadgetId(int userId, int badgetId)
        {
            return await _context.UserBadgets.FindAsync(userId, badgetId);
        }

        public async Task<IEnumerable<UserBadgets>> ListAsync()
        {
            return await _context.UserBadgets
                .Include(ub => ub.User)
                .Include(ub => ub.Badget)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserBadgets>> ListByBadgetIdAsync(int badgetId)
        {
            return await _context.UserBadgets
            .Where(ub => ub.BadgetId == badgetId)
            .Include(ub => ub.User)
            .Include(ub => ub.Badget)
            .ToListAsync();
        }

        public async Task<IEnumerable<UserBadgets>> ListByUserIdAsync(int userId)
        {
            return await _context.UserBadgets
            .Where(ub => ub.UserId == userId)
            .Include(ub => ub.User)
            .Include(ub => ub.Badget)
            .ToListAsync();
        }

        public void Remove(UserBadgets userBadgets)
        {
            _context.UserBadgets.Remove(userBadgets);
        }

        public async Task UnassignBadgetUser(int userId, int badgetId)
        {
            UserBadgets userBadgets = await FindByUserIdAndBadgetId(userId, badgetId);
            if (userBadgets != null)
            {
                Remove(userBadgets);
            }
        }
    }
}