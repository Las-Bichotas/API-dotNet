using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IBadgetsRespository
    {
        Task<IEnumerable<Badgets>> ListAsync();
        Task AddAsync(Badgets badget);
        Task FindById(int badgetId);
        void Update(Badgets badget);
        void Remove(Badgets badget);
    }
}