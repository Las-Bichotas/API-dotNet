using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface ISdayRepository
    {
        Task<IEnumerable<Sday>> ListAsync();
        Task AddAsync(Sday sday);
        void Remove(Sday sday);
        void Update(Sday sday);

        Task<Sday> FindById(int id);

        Task AssingSday(int id);
        

        
    }
}