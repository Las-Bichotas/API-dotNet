using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }

        public async Task AssingComment(int tutorId, int commentId)
        {
            User tutor = await _context.Users.FindAsync(tutorId);
            Comment comment = await _context.Comments.FindAsync(commentId);
            if (tutor != null && comment != null)
            {
                comment.TutorId = tutorId;
                Update(comment);
            }
        }

        public async Task<IEnumerable<Comment>> FindAllByTutorId(int tutorId)
        {
            return await _context.Comments.Where(c => c.TutorId == tutorId).ToListAsync();
        }

        public async Task<Comment> GetById(int commentId)
        {
            return await _context.Comments.FindAsync(commentId);
        }

        public async Task<IEnumerable<Comment>> ListAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public void Remove(Comment comment)
        {
            _context.Comments.Remove(comment);
        }

        public async Task UnassingComment(int tutorId, int commentId)
        {
            User tutor = await _context.Users.FindAsync(tutorId);
            Comment comment = await _context.Comments.FindAsync(commentId);
            if (tutor != null && comment != null)
            {
                comment.TutorId = 0;
                Update(comment);
            }
        }

        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
        }
    }
}