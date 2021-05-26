using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface ILanguageOfInterestService
    {
        Task<IEnumerable<LanguageOfInterest>> ListAsync();
        Task<IEnumerable<LanguageOfInterest>> ListGetByUserId(int userId);
        Task<LanguageOfInterestResponse> GetByIdAsync(int languageId);
        Task<LanguageOfInterestResponse> SaveAsync(LanguageOfInterest languageOf);
        Task<LanguageOfInterestResponse> UpdateAsync(int languageId, LanguageOfInterest languageOf);
        Task<LanguageOfInterestResponse> DeleteAsync(int languageId);

    }
}