using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Services
{
    public class LanguageOfInterestService : ILanguageOfInterestService
    {
        private readonly ILanguageOfInterestRespository _languageOfInterestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LanguageOfInterestService(ILanguageOfInterestRespository languageOfInterestRepository, IUnitOfWork unitOfWork)
        {
            _languageOfInterestRepository = languageOfInterestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LanguageOfInterestResponse> DeleteAsync(int languageId)
        {
            var existingLanguage = await _languageOfInterestRepository.FindByLanguageId(languageId);
            if (existingLanguage == null)
                return new LanguageOfInterestResponse("Language Not Found");
            try
            {
                _languageOfInterestRepository.Remove(existingLanguage);
                await _unitOfWork.CompleteAsync();
                return new LanguageOfInterestResponse(existingLanguage);
            }
            catch (Exception ex)
            {
                return new LanguageOfInterestResponse($"an error ocurrend while deleteing language: {ex.Message}");
            }
        }

        public async Task<LanguageOfInterestResponse> GetByIdAsync(int languageId)
        {
            var existingLanguage = await _languageOfInterestRepository.FindByLanguageId(languageId);
            if (existingLanguage == null)
                return new LanguageOfInterestResponse("Language not found");

            return new LanguageOfInterestResponse(existingLanguage);
        }

        public async Task<IEnumerable<LanguageOfInterest>> ListAsync()
        {
            return await _languageOfInterestRepository.ListAsync();
        }

        public async Task<LanguageOfInterestResponse> SaveAsync(LanguageOfInterest languageOf)
        {
            try
            {
                await _languageOfInterestRepository.AddAsync(languageOf);
                await _unitOfWork.CompleteAsync();
                return new LanguageOfInterestResponse(languageOf);
            }
            catch (Exception ex)
            {
                return new LanguageOfInterestResponse($"An error while saving language: {ex.Message}");
            }
        }

        public async Task<LanguageOfInterestResponse> UpdateAsync(int languageId, LanguageOfInterest languageOf)
        {
            var existingLanguage = await _languageOfInterestRepository.FindByLanguageId(languageId);
            if (existingLanguage == null)
                return new LanguageOfInterestResponse("Language Not Found");
            existingLanguage.Name = languageOf.Name;
            try
            {
                _languageOfInterestRepository.Update(existingLanguage);
                await _unitOfWork.CompleteAsync();
                return new LanguageOfInterestResponse(existingLanguage);
            }
            catch (Exception ex)
            {
                return new LanguageOfInterestResponse($"An error while updating language: {ex.Message}");
            }
        }
    }
}