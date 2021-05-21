using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services
{
    public interface ISuscriptionService
    {
        Task<IEnumerable<Suscription>> ListAsync();
        Task<SuscriptionResponse> GetById(int id);
       // Task<SuscriptionResponse> GetByName(string name);
       // Task<SuscriptionResponse> GetByDuration(int duration);
        Task<SuscriptionResponse> SaveAsync(Suscription suscription);
        Task<SuscriptionResponse> UpdateAsync(int id, Suscription suscription);
        Task<SuscriptionResponse> DeleteAsync(int id);

    }
}