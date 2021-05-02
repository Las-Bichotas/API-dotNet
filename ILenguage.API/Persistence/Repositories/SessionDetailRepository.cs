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
    public class SessionDetailRepository : BaseRepository, ISessionDetailRepository
    {
        public SessionDetailRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SessionDetails>> ListAsync()
        {
            return await _context.SessionsDetails.Include(p => p.User).ToListAsync();
        }



        public async Task<IEnumerable<SessionDetails>> ListByUserIdAsync(int userId)
        {
            return await _context.SessionsDetails
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<SessionDetails>> ListBySessionIdAsync(int sesssionId)
        {
            return await _context.SessionsDetails
                .Where(p => p.SessionId == sesssionId)
                .Include(p => p.Session)
                .ToListAsync();
        }


        public async Task AddAsync(SessionDetails sessionDetail)
        {
            await _context.SessionsDetails.AddAsync(sessionDetail);
        }

        public async Task<SessionDetails> FindById(int userId)
        {
            return await _context.SessionsDetails.FindAsync(userId);
        }

        public async Task<SessionDetails> FindBySessionId(int sessionId)
        {
            return await _context.SessionsDetails.FindAsync(sessionId);
        }



        public void Remove(SessionDetails sessionDetail)
        {
            _context.SessionsDetails.Remove(sessionDetail);
        }

        public void Update(SessionDetails sessionDetail)
        {
            _context.SessionsDetails.Update(sessionDetail);
        }
    }
}
