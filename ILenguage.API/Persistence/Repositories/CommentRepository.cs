using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;

namespace ILenguage.API.Persistence.Repositories
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Comment comment)
        {
            throw new System.NotImplementedException();
        }

        public Task AssingComment(int tutorId, int commentId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Comment>> FindAllByTutorId(int tutorId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Comment> GetById(int commentId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Comment>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Comment comment)
        {
            throw new System.NotImplementedException();
        }

        public Task UnassingComment(int tutorId, int commentId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Comment comment)
        {
            throw new System.NotImplementedException();
        }
    }
}