using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class LanguageOfInterestRepository : BaseRepository, ILanguageOfInterestRespository
    {
        public LanguageOfInterestRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(LanguageOfInterest languageOf)
        {
            await _context.LanguageOfInterests.AddAsync(languageOf);
        }

        public async Task<LanguageOfInterest> FindByLanguageId(int languageId)
        {
            return await _context.LanguageOfInterests.FindAsync(languageId);
        }

        public async Task<IEnumerable<LanguageOfInterest>> ListAsync()
        {
            return await _context.LanguageOfInterests.ToListAsync();
        }

        public void Remove(LanguageOfInterest languageOf)
        {
            _context.LanguageOfInterests.Remove(languageOf);
        }

        public void Update(LanguageOfInterest languageOf)
        {
            _context.LanguageOfInterests.Update(languageOf);
        }
    }
}