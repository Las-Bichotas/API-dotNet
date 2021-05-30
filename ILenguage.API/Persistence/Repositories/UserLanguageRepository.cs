using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class UserLanguageRepository : BaseRepository, IUserLanguageRepository
    {
        public UserLanguageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(UserLanguages userLanguages)
        {
            await _context.UserLanguages.AddAsync(userLanguages);
        }

        public async Task AssignLanguagUser(int userId, int languageId)
        {
            UserLanguages userLanguages = await FindByUserIdAndLanguageId(userId, languageId);
            if (userLanguages == null)
            {
                userLanguages = new UserLanguages { UserId = userId, LanguageId = languageId };
                await AddAsync(userLanguages);
            }

        }

        public async Task<UserLanguages> FindByUserIdAndLanguageId(int userId, int languageId)
        {
            return await _context.UserLanguages.FindAsync(userId, languageId);
        }

        public async Task<IEnumerable<UserLanguages>> ListAsync()
        {
            return await _context.UserLanguages
                .Include(ul => ul.User)
                .Include(ul => ul.LanguageOfInterest)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserLanguages>> ListByLanguageIdAsync(int languageId)
        {
            return await _context.UserLanguages
                .Where(ul => ul.LanguageId == languageId)
                .Include(ul => ul.User)
                .Include(ul => ul.LanguageOfInterest)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserLanguages>> ListByRoleIdAndLanguageId(int roleId, int languageId)
        {
            return await _context.UserLanguages
            .Where(ul => ul.User.RoleId == roleId && ul.LanguageId == languageId)
            .Include(ul => ul.User)
            .Include(ul => ul.LanguageOfInterest)
            .ToListAsync();
        }

        public async Task<IEnumerable<UserLanguages>> ListByUserIdAsync(int userId)
        {
            return await _context.UserLanguages
                .Where(ul => ul.UserId == userId)
                .Include(ul => ul.User)
                .Include(ul => ul.LanguageOfInterest)
                .ToListAsync();
        }

        public void Remove(UserLanguages userLanguages)
        {
            _context.UserLanguages.Remove(userLanguages);
        }

        public async Task UnassignLanguagUser(int userId, int languageId)
        {
            UserLanguages userLanguages = await FindByUserIdAndLanguageId(userId, languageId);
            if (userLanguages != null)
                Remove(userLanguages);
        }
    }
}