using ILenguage.API.Domain.Persistence.Contexts;

namespace ILenguage.API.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}