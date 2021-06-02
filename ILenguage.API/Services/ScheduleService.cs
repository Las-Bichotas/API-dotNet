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

        public async Task<ScheduleResponse> GetByIdAsync(int id)
        {
            var existingSchedule = await _scheduleRepository.FindById(id);
            if (existingSchedule == null)
                return new ScheduleResponse("Schedule Not Found");
            return new ScheduleResponse(existingSchedule);
        }

       
        public async Task<ScheduleResponse> SaveAsync(Schedule schedule)
        {
           try
            {
                await _scheduleRepository.AddAsync(schedule);
                await _unitOfWork.CompleteAsync();

                return new ScheduleResponse(schedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while saving Schedule: {ex.Message}");
            }
        }

        public async Task<ScheduleResponse> UpdateAsync(int id, Schedule schedule)
        {
            var existingSchedule = await _scheduleRepository.FindById(id);
            if (existingSchedule == null)
                return new ScheduleResponse("Schedule Not Found");
            existingSchedule.Day=schedule.Day;
            try
            {
                _scheduleRepository.Update(existingSchedule);
                await _unitOfWork.CompleteAsync();
                return new ScheduleResponse(existingSchedule);
            }
            catch (Exception e)
            {
                return new ScheduleResponse($"An error ocurred while deleting the schedule: {e.Message}");
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
