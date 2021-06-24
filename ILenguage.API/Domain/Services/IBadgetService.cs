using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface IBadgetService
    {
        Task<IEnumerable<Badgets>> ListAsync();
        Task<IEnumerable<Badgets>> ListByUserId(int userId);
        Task<BadgetsResponse> GetByIdAsync(int badgetId);
        Task<BadgetsResponse> SaveAsync(Badgets badget);
        Task<BadgetsResponse> UpdateAsync(int badgetId, Badgets badget);
        Task<BadgetsResponse> DeleteAsync(int badgetId);
    }
}