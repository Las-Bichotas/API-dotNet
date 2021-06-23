using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Services
{
    public class UserBadgetsService : IUserBadgetsService
    {
        public Task<UserBadgetsResponse> AssignBadgetUser(int userId, int badgetId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserBadgets>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserBadgets>> ListByBadgetId(int badgetId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserBadgets>> ListByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserBadgetsResponse> UnassignBadgetUser(int userId, int badgetId)
        {
            throw new System.NotImplementedException();
        }
    }
}