using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> ListAsync();
        Task<RoleResponse> GetByIdAsync(int id);
        Task<RoleResponse> SaveAsync(Role role);
        Task<RoleResponse> UpdateAsync(int id, Role role);
        Task<RoleResponse> DeleteAsync(int id);

    }
}
