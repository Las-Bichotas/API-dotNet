using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<IEnumerable<User>> ListByRoleId(int roleId);
        Task<IEnumerable<User>> ListTuthorsByLanguageIdAndTopicId(int languageId, int topicId);
        Task<IEnumerable<User>> ListByRoleIdAndTopicId(int roleId, int topicId);
        Task<IEnumerable<User>> ListByRoleIdAndLanguageId(int roleId, int languageId);
        Task<UserResponse> GetByIdAsync(int userId);
        Task<UserResponse> GetByEmailAndPasswordAsync(string email, string password);
        Task<UserResponse> SaveAsync(User user, int roleId);
        Task<UserResponse> UpdateAsync(int userId, User user);
        Task<UserResponse> DeleteAsync(int userId);

        Task<IEnumerable<User>> ListBySubscriptionId(int subscriptionId);
       

        /* */
        Task<IEnumerable<User>> ListBySessionIdAsync(int sessionId);
    }
}