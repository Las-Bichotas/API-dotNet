using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IUserLanguageRepository
    {
        Task<IEnumerable<UserLanguages>> ListAsync();
        Task<IEnumerable<UserLanguages>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserLanguages>> ListByLanguageIdAsync(int languageId);
        Task<IEnumerable<UserLanguages>> ListByRoleIdAndLanguageId(int roleId, int languageId);
        Task AssignLanguagUser(int userId, int languageId);
        Task UnassignLanguagUser(int userId, int languageId);
        Task<UserLanguages> FindByUserIdAndLanguageId(int userId, int languageId);
        void Remove(UserLanguages userLanguages);
        Task AddAsync(UserLanguages userLanguages);
    }
}