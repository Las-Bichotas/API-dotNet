using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;

namespace ILenguage.API.Persistence.Repositories
{
    public class UserBadgetsRespository : BaseRepository, IUserBadgetsRepository
    {
        public UserBadgetsRespository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(UserBadgets userBadgets)
        {
            throw new System.NotImplementedException();
        }

        public Task AssignBadgetUser(int userId, int badgetId)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserBadgets> FindByUserIdAndBadgetId(int userId, int BadgetId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserBadgets>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserBadgets>> ListByBadgetIdAsync(int badgetId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserBadgets>> ListByUserIdAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(UserBadgets userBadgets)
        {
            throw new System.NotImplementedException();
        }

        public Task UnassignBadgetUser(int userId, int badgetId)
        {
            throw new System.NotImplementedException();
        }
    }
}