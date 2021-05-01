using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> GetByIdAsync(int userId);
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int userId, User user);
        Task<UserResponse> DeleteAsync(int userId);
        Task<IEnumerable<User>> ListByUserIdAsync(int userId);
    }
}