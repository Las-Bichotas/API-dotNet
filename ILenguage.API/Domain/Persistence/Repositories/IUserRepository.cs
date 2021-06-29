using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> users();
        Task<IEnumerable<User>> ListAsync();
        Task<IEnumerable<User>> ListUsersByRoleId(int roleId);
        Task AddAsync(User user);
        Task<User> FindById(int userId);
        Task<User> FindByEmailAndPassword(string email, string password);
        void Update(User user);
        void Remove(User user);

        /*  */
        // Task<IEnumerable<User>> ListBySessionIdAsync(int sessionId);
        // public void AssignUserSession(User user, int sessionId);
    }
}