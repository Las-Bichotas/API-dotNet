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

    }
}