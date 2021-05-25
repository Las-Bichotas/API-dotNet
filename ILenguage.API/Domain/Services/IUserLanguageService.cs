using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface IUserLanguageService
    {
        Task<IEnumerable<UserLanguages>> ListAsync();
        Task<IEnumerable<UserLanguages>> ListByUserId(int userId);
        Task<IEnumerable<UserLanguages>> ListByLanguageId(int languageId);
        Task<UserLanguagesResponse> AssignLanguageUser(int userId, int languageId);
        Task<UserLanguagesResponse> UnassignLanguageUser(int userId, int languageId);
    }
}