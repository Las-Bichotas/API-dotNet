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
        Task<ScheduleResponse> GetByIdAsync(int id);
        
        Task<ScheduleResponse> DeleteAsync(int id);
        

        Task<ScheduleResponse> SaveAsync(Schedule Schedule);
        Task<ScheduleResponse> UpdateAsync(int id, Schedule Schedule);
    }
}

