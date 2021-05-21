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

        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _context.Suscriptions.ToListAsync();
            
        }

        public async Task AddAsync(Subscription subscription)
        {
            await _context.Suscriptions.AddAsync(subscription);
            _context.SaveChanges();
        }

        public async Task<Subscription> FindById(int id)
        {
            return await _context.Suscriptions.FindAsync(id);
        }

        public async Task<Subscription> FindByName(string name)
        {
            //?Does this really works?
            return await _context.Suscriptions.Where(s => s.Name == name)
                .FirstOrDefaultAsync();

        }

        public async Task<Subscription> FindByDuration(int duration)
        {
            return await _context.Suscriptions.Where(s => s.MonthDuration == duration)
                .FirstOrDefaultAsync();
        }

        public void Update(Subscription subscription)
        {
            _context.Update(subscription);
            _context.SaveChanges();
        }

        public void Remove(Subscription subscription)
        {
            _context.Suscriptions.Remove(subscription);
            _context.SaveChanges();
        }
        
    }
}