using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;
namespace ILanguage.API.Domain.Services
{
    public interface IScheduleService
    {

        Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId);

        Task<ScheduleResponse> GetByIdAsync(int id);
        Task<ScheduleResponse> SaveAsync(Schedule Schedule);
        Task<ScheduleResponse> UpdateAsync(int id, Schedule Schedule);
    }
}

