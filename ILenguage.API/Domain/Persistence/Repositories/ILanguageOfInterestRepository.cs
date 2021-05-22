using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface ILanguageOfInterestRespository
    {
        Task<IEnumerable<LanguageOfInterest>> ListAsync();
        Task AddAsync(LanguageOfInterest languageOf);
        Task<LanguageOfInterest> FindByLanguageId(int languageId);
        void Update(LanguageOfInterest languageOf);
        void Remove(LanguageOfInterest languageOf);
    }
}