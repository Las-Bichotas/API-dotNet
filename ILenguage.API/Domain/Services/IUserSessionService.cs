using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Services
{
    public interface IUserSessionService
    {
        Task<IEnumerable<UserSession>> ListAsync();
        Task<IEnumerable<UserSession>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserSession>> ListBySessionIdAsync(int sessionId);
        Task<IEnumerable<UserSession>> ListByStudentIdAndTutorIdAsync(int studentId, int tutorId);
        Task<UserSessionResponse> AssignUserSessionAsync(int userId, int sessionId);
        Task<UserSessionResponse> UnassignUserSessionAsync(int userId, int sessionId);
    }
}
