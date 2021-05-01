using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface IRelatedUserService
    {
        Task<IEnumerable<RelatedUser>> ListAsync();
        Task<IEnumerable<RelatedUser>> ListByIdAsync(int userId);
        Task<RelatedUserResponse> AssignUserAsync(int userOneId, int userTwoId);
        Task<RelatedUserResponse> UnassignUserAsync(int userOneId, int userTwoId);
    }
}