using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;

namespace ILanguage.API.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _ScheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleService(IScheduleRepository ScheduleRepository, IUnitOfWork unitOfWork)
        {
            _ScheduleRepository = ScheduleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId)
        {
            return await _ScheduleRepository.ListByUserIdAsync(userId);
        }

        public async Task<ScheduleResponse> GetByIdAsync(int id)
        {
            var existingSchedule = await _ScheduleRepository.FindById(id);

            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");
            return new ScheduleResponse(existingSchedule);
        }

        public async Task<ScheduleResponse> SaveAsync(Schedule Schedule)
        {
            try
            {
                await _ScheduleRepository.AddAsync(Schedule);
                await _unitOfWork.CompleteAsync();

                return new ScheduleResponse(Schedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while saving Schedule: {ex.Message}");
            }
        }

        public async Task<ScheduleResponse> UpdateAsync(int userId, Schedule Schedule)
        {
            var existingSchedule = await _ScheduleRepository.FindById(userId);
            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");

            existingSchedule.state = Schedule.state;

            try
            {
                _ScheduleRepository.Update(existingSchedule);
                await _unitOfWork.CompleteAsync();

                return new ScheduleResponse(existingSchedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while updating Schedule: {ex.Message}");
            }
        }

        public async Task<ScheduleResponse> DeleteAsync(int id)
        {
            var existingSchedule = await _ScheduleRepository.FindById(id);

            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");

            try
            {
                _ScheduleRepository.Remove(existingSchedule);
                await _unitOfWork.CompleteAsync();

                return new ScheduleResponse(existingSchedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while deleting Schedule: {ex.Message}");
            }
        }


    }
}
