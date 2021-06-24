using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> ListAsync();
        Task AddAsync(Comment comment);
        Task<IEnumerable<Comment>> FindAllByTutorId(int tutorId);
        Task<Comment> FindById(int commentId);
        Task AssingComment(int tutorId, int commentId);
        Task UnassingComment(int tutorId, int commentId);
        void Update(Comment comment);
        void Remove(Comment comment);
    }
}