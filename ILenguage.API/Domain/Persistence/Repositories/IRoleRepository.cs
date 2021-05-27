using ILenguage.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> ListAsync();
        Task AddAsync(Role role);
        Task<Role> FindById(int id);
        void Update(Role role);
        void Remove(Role role);
    }
}
