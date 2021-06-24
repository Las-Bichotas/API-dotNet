using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class BadgetsRepository : BaseRepository, IBadgetsRepository
    {
        public BadgetsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Badgets badget)
        {
            await _context.Badgets.AddAsync(badget);
        }

        public async Task<Badgets> FindById(int badgetId)
        {
            return await _context.Badgets.FindAsync(badgetId);
        }

        public async Task<IEnumerable<Badgets>> ListAsync()
        {
            return await _context.Badgets.ToListAsync();
        }

        public void Remove(Badgets badget)
        {
            _context.Badgets.Remove(badget);
        }

        public void Update(Badgets badget)
        {
            _context.Badgets.Update(badget);
        }
    }
}