using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Services
{
    public interface IScheduleService
    {
        Task<IEnumerable<Schedule>> ListAsync();
        Task<ScheduleResponse> GetById(int id);
        Task<ScheduleResponse> GetByName(string name);
        Task<ScheduleResponse> GetByHour(int hour);
        
        
        Task<ScheduleResponse> DeleteAsync(int id);
        Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId);

        Task<ScheduleResponse> SaveAsync(Schedule Schedule);
        Task<ScheduleResponse> UpdateAsync(int id, Schedule Schedule);
    }
}

