using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ILenguage.API.Persistence.Repositories
{
    public class SuscriptionRepository : BaseRepository, ISuscriptionRepository
    {
        public SuscriptionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Suscription>> ListAsync()
        {
            return await _context.Suscriptions.ToListAsync();
            
        }

        public async Task AddAsync(Suscription suscription)
        {
            await _context.Suscriptions.AddAsync(suscription);
            _context.SaveChanges();
        }

        public async Task<Suscription> FindById(int id)
        {
            return await _context.Suscriptions.FindAsync(id);
        }

        public async Task<Suscription> FindByName(string name)
        {
            //?Does this really works?
            return await _context.Suscriptions.Where(s => s.Name == name)
                .FirstOrDefaultAsync();

        }

        public async Task<Suscription> FindByDuration(int duration)
        {
            return await _context.Suscriptions.Where(s => s.MonthDuration == duration)
                .FirstOrDefaultAsync();
        }

        public void Update(Suscription suscription)
        {
            _context.Update(suscription);
            _context.SaveChanges();
        }

        public void Remove(Suscription suscription)
        {
            _context.Suscriptions.Remove(suscription);
            _context.SaveChanges();
        }
        
    }
}