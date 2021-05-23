using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IUserScheduleRepository
    {
        Task<IEnumerable<UserSchedule>> ListAsync();
        Task<IEnumerable<UserSchedule>> ListByUserId(int userId);
        Task<IEnumerable<UserSchedule>> ListByScheduleId(int scheduleId);
        Task<UserSchedule> FindByScheduleIdAndUserId(int userId, int scheduleId);
        Task AddAsync(UserSchedule userSchedule);
        void Remove(UserSchedule userSchedule);
        Task AssingUserSchedule(int userId, int scheduleId);
        Task UnassingUserSchedule(int userId, int scheduleId);
        

        
    }
}