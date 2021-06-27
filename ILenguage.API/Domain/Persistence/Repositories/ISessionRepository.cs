using ILenguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> ListAsync();

       

        Task AddAsync(Session session);

        Task<Session> FindById(int id);

        void Update(Session session);

        void Remove(Session session);

        
    }
}
