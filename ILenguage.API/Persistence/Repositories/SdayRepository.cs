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
        
        public async Task<Sday> FindById(int Id)
        {
            return await _context.Sdays.FindAsync(Id);
        }

        public void Remove(Sday sday)
        {
            _context.Sdays.Remove(sday);
            _context.SaveChanges();
        }

        public void Update(Sday sday)
        {
            _context.Update(sday);
            _context.SaveChanges();
        }
        public async Task AssingSday(int Id)
        {
            Sday sday = await FindById(Id);
            if (sday == null)
            {
                Sday foundSday = await _context.Sdays.FindAsync(Id);
                
                sday = new Sday {Id = Id};
                sday.InicialDay = DateTime.Now;
                

                await AddAsync(sday);
            }
        }
    }
}
