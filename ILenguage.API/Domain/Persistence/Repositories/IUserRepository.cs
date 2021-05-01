using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserSuscription>> ListAsync();
        Task<IEnumerable<UserSuscription>> ListByUserId(int userId);
        Task<IEnumerable<UserSuscription>> ListBySuscriptionId(int suscriptionId);
        Task<IEnumerable<UserSuscription>> ListBySuscriptionIdAndUserId(int suscriptionId, int userId);
        Task AddAsync(UserSuscription userSuscription);
        void Remove(UserSuscription userSuscription);
        //? do i have to do by this wy? 
        Task AssingUserSuscription(int userId, int suscriptionId);
        Task UnassingUserSuscription(int userId, int SuscriptionId);
        
    }
}