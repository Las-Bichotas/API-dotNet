using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface IUserScheduleService
    {
        Task<IEnumerable<UserSchedule>> ListAsync();
        Task<IEnumerable<UserSchedule>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserSchedule>> ListByScheduleId(int scheduleId);
        

    }
}