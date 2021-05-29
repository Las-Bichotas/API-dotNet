using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Services
{
    public interface ISessionDetailService
    {
        Task<IEnumerable<SessionDetail>> ListAsync();
        Task<IEnumerable<SessionDetail>> ListBySessionIdAsync(int sessionId);
        Task<SessionDetailResponse> GetByIdAsync(int id);
        Task<SessionDetailResponse> SaveAsync(SessionDetail sessionDetail);
        Task<SessionDetailResponse> UpdateAsync(int id, SessionDetail sessionDetail);
        Task<SessionDetailResponse> DeleteAsync(int id);
    }
}
