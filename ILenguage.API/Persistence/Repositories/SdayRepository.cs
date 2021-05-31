using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{

    public class SdayRepository : BaseRepository, ISdayRepository
    {

        public SdayRepository(AppDbContext context) : base(context)
        {
        }


          public async Task<IEnumerable<Sday>> ListAsync()
        {
            return await _context.Sdays.ToListAsync();
            
        }


        public async Task AddAsync(Sday sday)
        {
            await _context.Sdays.AddAsync(sday);
            _context.SaveChanges();

            
        }
        public void Update(Sday sday)
        {
            _context.Sdays.Update(sday);
        }
        public async Task<Sday> FindById(int id)
        {
            return await _context.Sdays.FindAsync(id);
        }

        public void Remove(Sday sday)
        {
            _context.Sdays.Remove(sday);
        }

        
        public async Task AssingSday(int id)
        {
            
                Sday foundSday = await _context.Sdays.FindAsync(id);
                
                var sday = new Sday {Id = id};
                sday.InicialDay = DateTime.Now;
                DateTime dt=sday.InicialDay;
                Console.WriteLine("The day of the week for {0:d} is {1}.", dt, dt.DayOfWeek);

                await AddAsync(sday);

                
            
        }
    }
}
