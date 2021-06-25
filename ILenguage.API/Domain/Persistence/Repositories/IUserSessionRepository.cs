using ILenguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IUserSessionRepository
    {
        Task<IEnumerable<UserSession>> ListAsync();
        Task<IEnumerable<UserSession>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserSession>> ListBySessionIdAsync(int sessionId);
        Task<IEnumerable<UserSession>> ListByStudentIdAndTutorIdAsync(int studentId, int tutorId);
        Task<UserSession> FindByUserIdAndSessionId(int userId, int sessionId);
        Task AddAsync(UserSession userSession);
        void Remove(UserSession userSession);
        Task AssignUserSession(int userId, int sessionId);
        Task UnassignUserSession(int userId, int sessionId);
    }
}
