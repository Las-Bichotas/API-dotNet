using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Services
{
    public interface ISessionService
    {
        Task<IEnumerable<Session>> ListAsync();
        Task<SessionResponse> GetByIdAsync(int id);
        Task<SessionResponse> SaveAsync(Session session);
        Task<SessionResponse> UpdateAsync(int id, Session session);
        Task<SessionResponse> DeleteAsync(int id);

        Task<SessionResponse> AssignSessionSchedule(Session session, int scheduleId);

        Task<IEnumerable<Session>> ListByScheduleIdAsync(int scheduleId);
    }
}
