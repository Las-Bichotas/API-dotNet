using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Services
{
    public class UserBadgetsService : IUserBadgetsService
    {
        private readonly IUserBadgetsRepository _userBadgetsRepository;
        private readonly IUnitOfWork _uniOfWork;

        public UserBadgetsService(IUserBadgetsRepository userBadgetsRepository, IUnitOfWork uniOfWork)
        {
            _userBadgetsRepository = userBadgetsRepository;
            _uniOfWork = uniOfWork;
        }

        public async Task<UserBadgetsResponse> AssignBadgetUser(int userId, int badgetId)
        {
            try
            {
                await _userBadgetsRepository.AssignBadgetUser(userId, badgetId);
                await _uniOfWork.CompleteAsync();
                UserBadgets userBadgets = await _userBadgetsRepository.FindByUserIdAndBadgetId(userId, badgetId);
                return new UserBadgetsResponse(userBadgets);
            }
            catch (Exception ex)
            {
                return new UserBadgetsResponse($"An errro ocurrend while assign badget to user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<UserBadgets>> ListAsync()
        {
            return await _userBadgetsRepository.ListAsync();
        }

        public async Task<IEnumerable<UserBadgets>> ListByBadgetId(int badgetId)
        {
            return await _userBadgetsRepository.ListByBadgetIdAsync(badgetId);
        }

        public async Task<IEnumerable<UserBadgets>> ListByUserId(int userId)
        {
            return await _userBadgetsRepository.ListByUserIdAsync(userId);
        }

        public async Task<UserBadgetsResponse> UnassignBadgetUser(int userId, int badgetId)
        {
            try
            {
                UserBadgets userBadgets = await _userBadgetsRepository.FindByUserIdAndBadgetId(userId, badgetId);
                _userBadgetsRepository.Remove(userBadgets);
                await _uniOfWork.CompleteAsync();
                return new UserBadgetsResponse(userBadgets);
            }
            catch (Exception ex)
            {
                return new UserBadgetsResponse($"An errro ocurrend while unassign badget to user: {ex.Message}");
            }
        }
    }
}