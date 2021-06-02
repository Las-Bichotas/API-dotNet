using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Services
{
    public class UserScheduleService : IUserScheduleService
    {
        private readonly IUserScheduleRepository _userScheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserScheduleService(IUserScheduleRepository userScheduleRepository, IUnitOfWork unitOfWork)
        {
            _userScheduleRepository = userScheduleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserSchedule>> ListAsync()
        {
            return await _userScheduleRepository.ListAsync();
        }

        public async Task<IEnumerable<UserSchedule>> ListByUserIdAsync(int userId)
        {
            return await _userScheduleRepository.ListByUserId(userId);
        }

        public async Task<IEnumerable<UserSchedule>> ListByScheduleId(int scheduleId)
        {
            return await _userScheduleRepository.ListByScheduleId(scheduleId);
        }
        
         public async Task<UserScheduleResponse> AssingUserScheduleAsync(int userId, int scheduleId)
        {
            try
            {
                
                var existingUserSchedule = await _userScheduleRepository.GetLastUserScheduleByUserIdAsync(userId);
                if (existingUserSchedule == null)
                {
                    await _userScheduleRepository.AssingUserSchedule(userId, scheduleId);
                    await _unitOfWork.CompleteAsync();
                    UserSchedule userScheduleWhenUserHasNoSchedule =
                        await _userScheduleRepository.FindByScheduleIdAndUserId(userId, scheduleId);
                    
                    return new UserScheduleResponse(userScheduleWhenUserHasNoSchedule);
                    
                }
               
                await _userScheduleRepository.AssingUserSchedule(userId, scheduleId);
                await _unitOfWork.CompleteAsync();
                UserSchedule userSchedule =
                    await _userScheduleRepository.FindByScheduleIdAndUserId(userId, scheduleId);
 
              
                return new UserScheduleResponse(userSchedule);
            }
            catch (Exception e)
            {
                return new UserScheduleResponse(
                    $"An error ocurred while assingin User to schedule: {e.Message} ");
            }
        }

        public async Task<UserScheduleResponse> UnassingUserScheduleAsync(int userId)
        {
            try
            {
                var existingUserSchedule =
                    await _userScheduleRepository.GetLastUserScheduleByUserIdAsync(userId);
                if (existingUserSchedule == null)
                    return new UserScheduleResponse("The user has never had a schedule");
                
                await _userScheduleRepository.UnassingUserSchedule(userId);
                return new UserScheduleResponse(existingUserSchedule);
                
            }
            catch (Exception e)
            {
                return new UserScheduleResponse(
                    $"An error ocurred while unassinging User From Schedule: {e.Message}");
            }
        }

    }
}