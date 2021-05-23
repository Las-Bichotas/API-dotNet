using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services
{
    public interface IUserLanguageService
    {
        Task<IEnumerable<UserLanguages>> ListAsync();
        Task<IEnumerable<UserLanguages>> ListByUserId(int userId);
        Task AssignLanguageUser(int userId, int languageId);
        Task UnassignLanguageUser(int userId, int languageId);
    }
}