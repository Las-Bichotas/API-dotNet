using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Persistence.Repositories
{
    public class UserSessionRepository : BaseRepository, IUserSessionRepository
    {
        public UserSessionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(UserSession userSession)
        {
            await _context.UserSessions.AddAsync(userSession);
        }

        public async Task AssignUserSession(int userId, int sessionId)
        {
            UserSession userSession= await FindByUserIdAndSessionId(userId, sessionId);
            if (userSession == null)
            {
                userSession = new UserSession { UserId = userId, SessionId = sessionId };
                await AddAsync(userSession);
            }
        }

        public async Task<UserSession> FindByUserIdAndSessionId(int userId, int sessionId)
        {
            return await _context.UserSessions.FindAsync(userId, sessionId);
        }

        public async Task<IEnumerable<UserSession>> ListAsync()
        {
            return await _context.UserSessions
              .Include(pt => pt.User)
              .Include(pt => pt.Session)
              .ToListAsync();
        }

        public async Task<IEnumerable<UserSession>> ListBySessionIdAsync(int sessionId)
        {
            return await _context.UserSessions
              .Where(pt => pt.SessionId == sessionId)
              .Include(pt => pt.User)
              .Include(pt => pt.Session)
              .ToListAsync();
        }

        public async Task<IEnumerable<UserSession>> ListByUserIdAndTutorIdAsync(int userId, int tutorId)
        {
            return await _context.UserSessions
              .Where(pt => pt.UserId == userId)
              .Where(pt => pt.UserId == tutorId)
              .Include(pt => pt.User)
              .Include(pt => pt.Session)
              .ToListAsync();
        }

        public async Task<IEnumerable<UserSession>> ListByUserIdAsync(int userId)
        {
            return await _context.UserSessions
              .Where(pt => pt.UserId == userId)
              .Include(pt => pt.User)
              .Include(pt => pt.Session)
              .ToListAsync();
        }

        public void Remove(UserSession userSession)
        {
            _context.UserSessions.Remove(userSession);
        }

        public async Task UnassignUserSession(int userId, int sessionId)
        {
            UserSession userSession= await FindByUserIdAndSessionId(userId, sessionId);
            if (userSession != null)
                Remove(userSession);
        }
    }
}
