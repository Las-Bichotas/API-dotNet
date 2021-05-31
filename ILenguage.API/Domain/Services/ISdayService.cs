using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface ISdayService
    {
        Task<IEnumerable<Sday>> ListAsync();

        Task<SdayResponse> GetByIdAsync(int id);
        Task<SdayResponse> DeleteAsync(int id);
        
        Task<SdayResponse> UpdateAsync(int id, Sday sday);

        Task<SdayResponse> SaveAsync(Sday Sday);
        Task<SdayResponse> AssingSdayAsync(int id);

    }
}