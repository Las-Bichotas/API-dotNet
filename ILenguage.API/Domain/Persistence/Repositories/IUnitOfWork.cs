using System.Threading.Tasks;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}