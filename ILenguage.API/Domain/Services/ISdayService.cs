using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface ISdayService
    {
        Task<IEnumerable<UserSubscription>> ListAsync();

        Task<SdayResponse> GetById(int id);
        
        Task<SdayResponse> DeleteAsync(int id);
        

        Task<SdayResponse> SaveAsync(Sday Sday);
        Task<SdayResponse> UpdateAsync(int id, Sday Sday);
        Task<SdayResponse> AssingSdayAsync(int id, Sday Sday);

    }
}