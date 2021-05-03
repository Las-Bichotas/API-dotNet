using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class RelatedUserRepository : BaseRepository, IRelatedUserRepository
    {
        public RelatedUserRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(RelatedUser relatedUser)
        {
            throw new System.NotImplementedException();
        }

        public Task AssignRelatedUser(int userOneId, int userTwoId)
        {
            throw new System.NotImplementedException();
        }

        public Task<RelatedUser> FindByUserOneIdAndUserTwoId(int userOneId, int userTwoId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<RelatedUser>> ListAsyn()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<RelatedUser>> ListByUserIdAsyn(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(RelatedUser relatedUser)
        {
            throw new System.NotImplementedException();
        }

        public Task UnaAssignRelatedUser(int userOneId, int userTwoId)
        {
            throw new System.NotImplementedException();
        }
    }
}