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
    public class SubscriptionRepository : BaseRepository, ISubscriptionRepository
    {
        public SubscriptionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _context.Subscriptions.ToListAsync();
            
        }

        public async Task AddAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
            _context.SaveChanges();
        }

        public async Task<Subscription> FindById(int id)
        {
            return await _context.Subscriptions.FindAsync(id);
        }

        public async Task<Subscription> FindByName(string name)
        {
            //?Does this really works?
            return await _context.Subscriptions.Where(s => s.Name == name)
                .FirstOrDefaultAsync();

        }

        public async Task<Subscription> FindByDuration(int duration)
        {
            return await _context.Subscriptions.Where(s => s.MonthDuration == duration)
                .FirstOrDefaultAsync();
        }

        public void Update(Subscription subscription)
        {
            _context.Update(subscription);
            _context.SaveChanges();
        }

        public void Remove(Subscription subscription)
        {
            _context.Subscriptions.Remove(subscription);
            _context.SaveChanges();
        }
        
    }
}