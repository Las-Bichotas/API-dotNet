using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> ListAsync();
        Task<IEnumerable<Comment>> ListByTutorId(int tutorId);
        Task<CommentResponse> GetById(int commentId);
        Task<CommentResponse> SaveAsync(Comment comment);
        Task<CommentResponse> Update(int commentId, Comment comment);
        Task<CommentResponse> Delete(int commentId);
        Task<CommentResponse> AssignComment(int tutorId, int commentId);
        Task<CommentResponse> UnassignComment(int tutorId, int commentId);
    }
}