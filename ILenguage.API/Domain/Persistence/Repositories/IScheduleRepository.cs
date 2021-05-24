using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IScheduleRepository
    {
       Task<IEnumerable<Schedule>> ListAsync();
        Task AddAsync(Schedule Schedule);
        Task<Schedule> FindById(int id);
       
        void Update(Schedule Schedule);
        void Remove(Schedule Schedule);
    }
}