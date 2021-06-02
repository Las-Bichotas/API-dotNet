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


          public async Task<IEnumerable<Schedule>> ListAsync()
        {
            return await _context.Schedules.ToListAsync();
            
        }


        public async Task AddAsync(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            _context.SaveChanges();
        }
        
        public async Task<Schedule> FindById(int scheduleId)
        {
            return await _context.Schedules.FindAsync(scheduleId);
        }

        public void Remove(Schedule schedule)
        {
            _context.Schedules.Remove(schedule);
            _context.SaveChanges();
        }

        public void Update(Schedule schedule)
        {
            _context.Update(schedule);
            _context.SaveChanges();
        }
    }
}
