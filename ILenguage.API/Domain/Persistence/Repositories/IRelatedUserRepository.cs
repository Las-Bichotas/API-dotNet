using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IRelatedUserRepository
    {
        Task<IEnumerable<RelatedUser>> ListAsyn();
        Task<IEnumerable<RelatedUser>> ListByUserIdAsyn(int userId);
        Task<RelatedUser> FindByUserOneIdAndUserTwoId(int userOneId, int userTwoId);
        Task AddAsync(RelatedUser relatedUser);
        void Remove(RelatedUser relatedUser);
        Task AssignRelatedUser(int userOneId, int userTwoId);
        Task UnaAssignRelatedUser(int userOneId, int userTwoId);
    }
}