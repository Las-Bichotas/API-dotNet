using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Services
{
    public class BadgetsService : IBadgetService
    {
        private readonly IBadgetsRepository _badgetRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserBadgetsRepository _userBadgetRepository;
        public BadgetsService(IBadgetsRepository badgetRepository, IUnitOfWork unitOfWork, IUserBadgetsRepository userBadgetRepository)
        {
            _badgetRepository = badgetRepository;
            _unitOfWork = unitOfWork;
            _userBadgetRepository = userBadgetRepository;
        }

        public async Task<BadgetsResponse> DeleteAsync(int badgetId)
        {
            var existingBadgets = await _badgetRepository.FindById(badgetId);
            if (existingBadgets == null)
                return new BadgetsResponse("Badgets Not Found");
            try
            {
                _badgetRepository.Remove(existingBadgets);
                await _unitOfWork.CompleteAsync();
                return new BadgetsResponse(existingBadgets);
            }
            catch (Exception ex) { return new BadgetsResponse($"An error ocurred while deleteting badget: {ex.Message}"); }
        }

        public async Task<BadgetsResponse> GetByIdAsync(int badgetId)
        {
            var existingBadget = await _badgetRepository.FindById(badgetId);
            if (existingBadget == null)
                return new BadgetsResponse("Badget Not Found");
            return new BadgetsResponse(existingBadget);
        }

        public async Task<IEnumerable<Badgets>> ListAsync()
        {
            return await _badgetRepository.ListAsync();
        }

        public async Task<IEnumerable<Badgets>> ListByUserId(int userId)
        {
            var userBadgets = await _userBadgetRepository.ListByUserIdAsync(userId);
            var badgets = userBadgets.Select(ub => ub.Badget).ToList();
            return badgets;
        }

        public async Task<BadgetsResponse> SaveAsync(Badgets badget)
        {
            try
            {
                await _badgetRepository.AddAsync(badget);
                await _unitOfWork.CompleteAsync();
                return new BadgetsResponse(badget);
            }
            catch (Exception ex)
            {
                return new BadgetsResponse($"An error while saving badget: {ex.Message}");
            }
        }

        public async Task<BadgetsResponse> UpdateAsync(int badgetId, Badgets badget)
        {
            var existingBadget = await _badgetRepository.FindById(badgetId);
            if (existingBadget == null)
                return new BadgetsResponse("Badget Not Found");
            existingBadget.Title = badget.Title;
            existingBadget.Description = badget.Description;
            existingBadget.ImgSrc = badget.ImgSrc;
            try
            {
                _badgetRepository.Update(existingBadget);
                await _unitOfWork.CompleteAsync();
                return new BadgetsResponse(existingBadget);
            }
            catch (Exception ex)
            {
                return new BadgetsResponse($"An error while updating badget: {ex.Message}");
            }
        }
    }
}