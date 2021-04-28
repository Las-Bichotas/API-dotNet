using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface ISuscriptionRepository
    {
        Task<IEnumerable<Suscription>> ListAsync();
        Task AddAsync(Suscription suscription);
        Task<Suscription> FindById(int id);
        Task<Suscription> FindByName(string name);
        Task<Suscription> FindByDuration(int duration);
        void Update(Suscription suscription);
        void Remove(Suscription suscription);
    }
}