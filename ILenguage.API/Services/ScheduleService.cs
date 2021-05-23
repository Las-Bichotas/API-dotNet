using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleService(IScheduleRepository ScheduleRepository, IUnitOfWork unitOfWork)
        {
            _scheduleRepository = ScheduleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Schedule>> ListAsync()
        {
            return await _scheduleRepository.ListAsync();
        }

        public async Task<ScheduleResponse> GetById(int id)
        {
            var existingSchedule = await _scheduleRepository.FindById(id);
            if (existingSchedule == null)
                return new ScheduleResponse("Schedule Not Found");
            return new ScheduleResponse(existingSchedule);
        }

        public async Task<ScheduleResponse> GetByName(string name)
        {
            var existingSchedule = await _scheduleRepository.FindByName(name);
            if (existingSchedule == null)
                return new ScheduleResponse("Schedule Not Found");
            return new ScheduleResponse(existingSchedule);
            
        }
        
        public async Task<ScheduleResponse> GetByHour(int hour)
        {
            var existingSchedule = await _scheduleRepository.FindByHour(hour);
            if (existingSchedule == null)
                return new ScheduleResponse("Schedule Not Found");
            return new ScheduleResponse(existingSchedule);
        }
        public async Task<ScheduleResponse> GetByDay(string day)
        {
            var existingSchedule = await _scheduleRepository.FindByDay(day);
            if (existingSchedule == null)
                return new ScheduleResponse("Schedule Not Found");
            return new ScheduleResponse(existingSchedule);
            
        }
        public async Task<ScheduleResponse> SaveAsync(Schedule schedule)
        {
            var existingScheduleByHour = await _scheduleRepository.FindByHour(schedule.HourDuration);
            var existingScheduleByName = await _scheduleRepository.FindByName(schedule.Name);
            var existingScheduleByDay = await _scheduleRepository.FindByDay(schedule.Day);
            if (existingScheduleByHour != null)
                return new ScheduleResponse("There is already a schedule with that time");
            if(existingScheduleByName != null)
                return new ScheduleResponse("There already exist a Course with that name");
             if(existingScheduleByDay != null)
                return new ScheduleResponse("There already exist a Schedule with that Day");
            try
            {
                await _scheduleRepository.AddAsync(schedule);
                await _unitOfWork.CompleteAsync();
                return new ScheduleResponse(schedule);
            }
            catch (Exception e)
            {
                return new ScheduleResponse($"An error ocurred while saving the schedule {e.Message}");
            }
        }

        public async Task<ScheduleResponse> UpdateAsync(int id, Schedule schedule)
        {
            var existingSchedule = await _scheduleRepository.FindById(id);
            if (existingSchedule == null)
                return new ScheduleResponse("Schedule Not Found");
            
            var existingScheduleByHour = await _scheduleRepository.FindByHour(schedule.HourDuration);
            var existingScheduleByName = await _scheduleRepository.FindByName(schedule.Name);
            var existingScheduleByDay = await _scheduleRepository.FindByDay(schedule.Day);
            if (existingScheduleByHour != null)
                return new ScheduleResponse("There is already a schedule with that time");
            if(existingScheduleByName != null)
                return new ScheduleResponse("There already exist a Course with that name");
             if(existingScheduleByDay != null)
                return new ScheduleResponse("There already exist a Schedule with that Day");           
            
            existingSchedule.Name = schedule.Name;
            existingSchedule.Day = schedule.Day;
            existingSchedule.HourDuration = schedule.HourDuration;
            try
            {
                _scheduleRepository.Update(existingSchedule);
                await _unitOfWork.CompleteAsync();
                return new ScheduleResponse(existingSchedule);
            }
            catch (Exception e)
            {
                return new ScheduleResponse($"An error ocurred while saving the schedule {e.Message}");
            }
        }

        public async Task<ScheduleResponse> DeleteAsync(int id)
        {
            var existingSchedule = await _scheduleRepository.FindById(id);
            if (existingSchedule == null)
                return new ScheduleResponse("Schedule Not Found");
            try
            {
                _scheduleRepository.Remove(existingSchedule);
                await _unitOfWork.CompleteAsync();
                return new ScheduleResponse(existingSchedule);
            }
            catch (Exception e)
            {
                return new ScheduleResponse($"An error ocurred while deleting the schedule: {e.Message}");
            }
        }


    }
}
