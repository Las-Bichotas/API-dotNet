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

        public async Task AddAsync(SessionDetail sessionDetail, int sessionId)
        {
            //sessionDetail = new SessionDetail { SessionId = sessionId };
            sessionDetail.SessionId = sessionId;
            await _context.SessionsDetails.AddAsync(sessionDetail);
        }
        /*
        public async Task AssignSessionSessionDetail(int sessionId, int sessionDetailId)
        {
            SessionDetail sessionDetail = await FindById(sessionDetailId);
            if (sessionDetail != null)
            {
                sessionDetail = new SessionDetail { SessionId = sessionId };
                await AddAsync(sessionDetail);
            }

        }
        */
        public async Task<SessionDetail> FindById(int id)
        {
            return await _context.SessionsDetails.FindAsync(id);
        }

        public async Task<IEnumerable<SessionDetail>> GetBySessionIdAsync(int sessionId)
        {
            return await _context.SessionsDetails
              .Where(p => p.SessionId == sessionId)
              .Include(p => p.Session)
              .ToListAsync();
        }

        public async Task<IEnumerable<SessionDetail>> ListAsync()
        {
            return await _context.SessionsDetails.Include(p => p.Session).ToListAsync();
        }

        public async Task<IEnumerable<SessionDetail>> ListBySessionIdAsync(int sessionId)
        {
            return await _context.SessionsDetails
               .Where(p => p.SessionId == sessionId)
               .Include(p => p.Session)
               .ToListAsync();
        }

        public void Remove(SessionDetail sessionDetail)
        {
            _context.SessionsDetails.Remove(sessionDetail);
        }

        public void Update(SessionDetail sessionDetail)
        {
            _context.SessionsDetails.Update(sessionDetail);
        }
    }
}