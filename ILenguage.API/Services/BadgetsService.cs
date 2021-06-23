using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Services
{
    public class BadgetsService : IBadgetService
    {
        private readonly IBadgetsRepository _badgetRepository;
        private readonly IUnitOfWork _unitOfWork;
        public Task<BadgetsResponse> DeleteAsync(int badgetId)
        {
            throw new System.NotImplementedException();
        }

        public Task<BadgetsResponse> GetByIdAsync(int badgetId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Badgets>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Badgets>> ListByBadgetId(int badgetId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Badgets>> ListByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<BadgetsResponse> SaveAsync(Badgets badget)
        {
            throw new System.NotImplementedException();
        }

        public Task<BadgetsResponse> UpdateAsync(int badgetId, Badgets badget)
        {
            throw new System.NotImplementedException();
        }
    }
}