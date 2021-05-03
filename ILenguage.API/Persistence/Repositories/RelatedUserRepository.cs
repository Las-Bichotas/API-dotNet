using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class RelatedUserRepository : BaseRepository, IRelatedUserRepository
    {
        public RelatedUserRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<RelatedUser>> ListAsyn()
        {
            return await _context.RelatedUsers
            .Include(u => u.UserOne)
            .Include(u => u.UserTwo)
            .ToListAsync();
        }
        public async Task AddAsync(RelatedUser relatedUser)
        {
            await _context.RelatedUsers.AddAsync(relatedUser);
        }

        public async Task AssignRelatedUser(int userOneId, int userTwoId)
        {
            RelatedUser relatedUser = await FindByUserOneIdAndUserTwoId(userOneId, userTwoId);
            if (relatedUser == null)
            {
                relatedUser = new RelatedUser { UserIdOne = userOneId, UserIdTwo = userTwoId };
                await AddAsync(relatedUser);
            }
        }

        public async Task<RelatedUser> FindByUserOneIdAndUserTwoId(int userOneId, int userTwoId)
        {
            return await _context.RelatedUsers.FindAsync(userOneId, userTwoId);
        }


        public async Task<IEnumerable<RelatedUser>> ListByUserIdAsyn(int userId)
        {
            return await _context.RelatedUsers
            .Where(u => u.UserIdTwo == userId)
            .Include(u => u.UserOne)
            .Include(u => u.UserTwo)
            .ToListAsync();
        }

        public void Remove(RelatedUser relatedUser)
        {
            _context.RelatedUsers.Remove(relatedUser);
        }

        public async Task UnaAssignRelatedUser(int userOneId, int userTwoId)
        {
            RelatedUser relatedUser = await FindByUserOneIdAndUserTwoId(userOneId, userTwoId);
            if (relatedUser != null)
                Remove(relatedUser);
        }
    }
}