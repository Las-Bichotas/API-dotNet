using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class UserScheduleRepository : BaseRepository, IUserScheduleRepository
    {
        public UserScheduleRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<UserSchedule>> ListAsync()
        {
        
            return await _context.UserSchedules.Include(us => us.Schedule)
                .Include(us => us.User)
                .ToListAsync();
            
        }
        public async Task<IEnumerable<UserSchedule>> ListByUserId(int userId)
        {
            return await _context.UserSchedules.Where(us => us.UserId == userId)
                .Include(us => us.Schedule)
                .Include(us => us.User)
                .ToListAsync();
        

        }

        public async Task<IEnumerable<UserSchedule>> ListByScheduleId(int scheduleId)
        {
            return await _context.UserSchedules.Where(us => us.ScheduleId == scheduleId)
                .Include(us => us.Schedule)
                .Include(us => us.User)
                .ToListAsync();
           

        }

        public async Task<UserSchedule> FindByScheduleIdAndUserId(int userId, int scheduleId)
        {
            return await _context.UserSchedules
                .Include(sub=> sub.User)
                .Include(sub => sub.Schedule)
                .FirstOrDefaultAsync(us => us.UserId == userId && us.ScheduleId == scheduleId);
        }

        public async Task AddAsync(UserSchedule userSchedule)
        {
            await _context.UserSchedules.AddAsync(userSchedule);
        }

        public void Remove(UserSchedule userSchedule)
        {
            _context.UserSchedules.Remove(userSchedule);
        }

        public async Task AssingUserSchedule(int userId, int scheduleId)
        {
            UserSchedule userSchedule = await FindByScheduleIdAndUserId(userId, scheduleId);
            if (userSchedule == null)
            {
                Schedule foundSchedule = await _context.Schedules.FindAsync(scheduleId);
                
                userSchedule = new UserSchedule {UserId = userId, ScheduleId = scheduleId};
                userSchedule.InitialDate = DateTime.Now;
                userSchedule.FinalDate =
                    userSchedule.InitialDate.AddHours(foundSchedule.HourDuration);

                await AddAsync(userSchedule);
            }
        }

        public async Task UnassingUserSchedule(int userId, int scheduleId)
        {
            UserSchedule userSchedule = await FindByScheduleIdAndUserId(scheduleId, userId);
            if (userSchedule != null)
                Remove(userSchedule);
        }

        

       
        
    }
}