using ILenguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface ISessionDetailRepository
    {
        Task<IEnumerable<SessionDetail>> ListAsync();
        Task<IEnumerable<SessionDetail>> GetBySessionIdAsync(int sessionId);
        Task AddAsync(SessionDetail sessionDetail, int sessionId);
        Task<SessionDetail> FindById(int id);
        void Update(SessionDetail sessionDetail);
        void Remove(SessionDetail sessionDetail);
        //Task AssignSessionSessionDetail(int sessionId, int sessionDetailId);
    }
}
