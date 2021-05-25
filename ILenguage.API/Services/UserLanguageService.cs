using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Services
{
    public class UserLanguageService : IUserLanguageService
    {
        private readonly IUserLanguageRepository _userLanguageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserLanguageService(IUserLanguageRepository userLanguageRepository, IUnitOfWork unitOfWork)
        {
            _userLanguageRepository = userLanguageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserLanguagesResponse> AssignLanguageUser(int userId, int languageId)
        {
            try
            {
                await _userLanguageRepository.AssignLanguagUser(userId, languageId);
                await _unitOfWork.CompleteAsync();
                UserLanguages userLanguages = await _userLanguageRepository.FindByUserIdAndLanguageId(userId, languageId);
                return new UserLanguagesResponse(userLanguages);
            }
            catch (Exception ex)
            {
                return new UserLanguagesResponse($"An error ocurrend while assing langauge to user: {ex.Message}");
            }
        }
        public async Task<IEnumerable<UserLanguages>> ListAsync()
        {
            return await _userLanguageRepository.ListAsync();
        }

        public async Task<IEnumerable<UserLanguages>> ListByLanguageId(int languageId)
        {
            return await _userLanguageRepository.ListByLanguageIdAsync(languageId);
        }

        public async Task<IEnumerable<UserLanguages>> ListByUserId(int userId)
        {
            return await _userLanguageRepository.ListByUserIdAsync(userId);
        }

        public async Task<UserLanguagesResponse> UnassignLanguageUser(int userId, int languageId)
        {
            try
            {
                UserLanguages userLanguages = await _userLanguageRepository.FindByUserIdAndLanguageId(userId, languageId);
                _userLanguageRepository.Remove(userLanguages);
                await _unitOfWork.CompleteAsync();
                return new UserLanguagesResponse(userLanguages);
            }
            catch (Exception ex)
            {
                return new UserLanguagesResponse($"An error ocurred while unassign language to user: {ex.Message}");
            }
        }
    }
}