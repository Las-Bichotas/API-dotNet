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

        public async Task<CommentResponse> AssignComment(int tutorId, int commentId)
        {
            try
            {
                await _commentRepository.AssingComment(tutorId, commentId);
                await _unitOfWork.CompleteAsync();
                Comment comment = await _commentRepository.GetById(commentId);
                return new CommentResponse(comment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurrend while assigning comment to user: {ex.Message}");
            }
        }

        public async Task<CommentResponse> Delete(int commentId)
        {
            var existingComment = await _commentRepository.GetById(commentId);
            if (existingComment == null)
                return new CommentResponse("Comment not found");
            try
            {
                _commentRepository.Remove(existingComment);
                await _unitOfWork.CompleteAsync();
                return new CommentResponse(existingComment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurrend while deleting comment: {ex.Message}");
            }
        }

        public async Task<CommentResponse> GetById(int commentId)
        {
            var existingComment = await _commentRepository.GetById(commentId);
            if (existingComment == null)
                return new CommentResponse("Comment not found");
            return new CommentResponse(existingComment);
        }

        public async Task<IEnumerable<Comment>> ListAsync()
        {
            return await _commentRepository.ListAsync();
        }

        public async Task<IEnumerable<Comment>> ListByTutorId(int tutorId)
        {
            return await _commentRepository.FindAllByTutorId(tutorId);
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

        public async Task<CommentResponse> UnassignComment(int tutorId, int commentId)
        {
            try
            {
                await _commentRepository.UnassingComment(tutorId, commentId);
                await _unitOfWork.CompleteAsync();
                Comment comment = await _commentRepository.GetById(commentId);
                return new CommentResponse(comment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurrend while assigning comment to user: {ex.Message}");
            }
        }

        public async Task<CommentResponse> Update(int commentId, Comment comment)
        {
            var existingComment = await _commentRepository.GetById(commentId);
            if (existingComment == null)
                return new CommentResponse("Comment not found");
            existingComment.Content = comment.Content;
            existingComment.Rating = comment.Rating;
            existingComment.date = comment.date;
            try
            {
                _commentRepository.Update(existingComment);
                await _unitOfWork.CompleteAsync();
                return new CommentResponse(existingComment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error while updating comment: {ex.Message}");
            }
        }
    }
}