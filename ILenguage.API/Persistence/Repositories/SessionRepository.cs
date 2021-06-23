using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Resources;

namespace ILenguage.API.Persistence.Repositories
{
    public class SessionRepository : BaseRepository, ISessionRepository
    {
        public SessionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Session session)
        {
            await _context.Sessions.AddAsync(session);
        }

        public void AssignSessionSchedule(Session session, int scheduleId)
        {
            session.ScheduleId = scheduleId;
            _context.Sessions.Update(session);
        }

        public void AssignSessionUser(Session session, int userId)
        {
            session.UserId = userId;
            _context.Sessions.Update(session);
        }

        public async Task<Session> FindById(int id)
        {
            return await _context.Sessions.FindAsync(id);
        }

        public async Task<IEnumerable<Session>> ListAsync()
        {
            return await _context.Sessions.ToListAsync();
        }

        public async Task<IEnumerable<Session>> ListByScheduleIdAsync(int scheduleId)
        {
            return await _context.Sessions
               .Where(p => p.ScheduleId == scheduleId)
               .Include(p => p.Schedule)
               .ToListAsync();
        }

        public Task<IEnumerable<Session>> ListByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Session session)
        {
            _context.Sessions.Remove(session);
        }

        public void Update(Session session)
        {
            _context.Sessions.Update(session);
        }
    }
}
