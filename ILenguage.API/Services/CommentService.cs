using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Services
{
    public class CommentService : ICommentService
    {
        public readonly ICommentRepository _commentRepository;
        public readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<CommentResponse> AssignComment(int tutorId, int commentId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CommentResponse> Delete(int commentId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CommentResponse> GetById(int commentId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Comment>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Comment>> ListByTutorId(int tutorId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CommentResponse> SaveAsync(Comment comment)
        {
            try
            {
                await _commentRepository.AddAsync(comment);
                await _unitOfWork.CompleteAsync();
                return new CommentResponse(comment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error while saving comment:{ex.Message}");
            }
        }

        public Task<CommentResponse> UnassignComment(int tutorId, int commentId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CommentResponse> Update(int commentId, Comment comment)
        {
            throw new System.NotImplementedException();
        }
    }
}