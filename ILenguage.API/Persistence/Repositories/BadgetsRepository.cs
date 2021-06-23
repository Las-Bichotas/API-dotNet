using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;

namespace ILenguage.API.Persistence.Repositories
{
    public class BadgetsRepository : BaseRepository, IBadgetsRespository
    {
        public BadgetsRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Badgets badget)
        {
            throw new System.NotImplementedException();
        }

        public Task FindById(int badgetId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Badgets>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Badgets badget)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Badgets badget)
        {
            throw new System.NotImplementedException();
        }
    }
}