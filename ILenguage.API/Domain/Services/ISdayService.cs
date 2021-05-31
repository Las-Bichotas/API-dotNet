using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface ISdayService
    {
        Task<IEnumerable<Sday>> ListAsync();

        Task<SdayResponse> GetById(int id);
        Task<SdayResponse> AssingSdayAsync(int id);

    }
}