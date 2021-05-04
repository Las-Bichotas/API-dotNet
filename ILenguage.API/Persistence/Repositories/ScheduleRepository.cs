using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{

    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {

        public ScheduleRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId)
        {
            return await _context.Schedules
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task AddAsync(Schedule Schedule)
        {
            await _context.Schedules.AddAsync(Schedule);
        }

        public async Task<Schedule> FindById(int userId)
        {
            return await _context.Schedules.FindAsync(userId);
        }

        public void Remove(Schedule Schedule)
        {
            _context.Schedules.Remove(Schedule);
        }

        public void Update(Schedule Schedule)
        {
            _context.Schedules.Update(Schedule);
        }
    }
}
