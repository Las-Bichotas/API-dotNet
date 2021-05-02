using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;

namespace ILenguage.API.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(User user)
        {
            throw new System.NotImplementedException();
        }
        public Task<User> FindById(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> ListByUserIdAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}