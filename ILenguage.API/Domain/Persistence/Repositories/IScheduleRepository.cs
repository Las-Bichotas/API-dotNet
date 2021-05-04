using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId);

        Task AddAsync(Schedule Schedule);
        Task<Schedule> FindById(int userId);
        void Update(Schedule Schedule);
        void Remove(Schedule Schedule);
    }
}