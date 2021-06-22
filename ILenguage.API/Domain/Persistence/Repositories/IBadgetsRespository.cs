namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IBadgetsRespository
    {
        Task<IEnumerable<Badgets> ListAsync();  
    }
}