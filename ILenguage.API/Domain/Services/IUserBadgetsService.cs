using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface IUserBadgetsService
    {
        Task<IEnumerable<UserBadgets>> ListAsync();
        Task<IEnumerable<UserBadgets>> ListByUserId(int userId);
        Task<IEnumerable<UserBadgets>> ListByBadgetId(int badgetId);
        Task<UserBadgetsResponse> AssignBadgetUser(int userId, int badgetId);
        Task<UserBadgetsResponse> UnassignBadgetUser(int userId, int badgetId);
    }
}