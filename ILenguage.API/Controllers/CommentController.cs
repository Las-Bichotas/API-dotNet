using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services;
using ILenguage.API.Extensions;
using ILenguage.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ILenguage.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentservice;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService commentservice, IMapper mapper)
        {
            _commentservice = commentservice;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Add new comment",
            Description = "Add new comment with initial data",
            OperationId = "AddComment"
        )]
        [SwaggerResponse(200, "Comment Added", typeof(CommentResource))]
        [ProducesResponseType(typeof(CommentResource), 200)]
        [Produces("application/json")]
        public async Task<ActionResult> PostAsync([FromBody] SaveCommentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var comment = _mapper.Map<SaveCommentResource, Comment>(resource);
            var result = await _commentservice.SaveAsync(comment);
            if (!result.Succes)
                return BadRequest(result.Message);
            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }
        [HttpGet("{commentId}")]
        [SwaggerOperation(
            Summary = "Get Comment",
            Description = "Get Comment In the Data Base by id",
            OperationId = "GetComment"
        )]
        [SwaggerResponse(200, "Returned Comment", typeof(CommentResource))]
        [ProducesResponseType(typeof(CommentResource), 200)]
        [Produces("application/json")]
        public async Task<ActionResult> GetActionAsync(int commentId)
        {
            var result = await _commentservice.GetById(commentId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }
        [HttpDelete("{commentId}")]
        [SwaggerOperation(
            Summary = "Delete Comment",
            Description = "Delete Comment In the Data Base by id",
            OperationId = "DeleteComment"
        )]
        [SwaggerResponse(200, "Deleted Comment", typeof(CommentResource))]
        [ProducesResponseType(typeof(CommentResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync(int commentId)
        {
            var result = await _commentservice.Delete(commentId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All Comment",
            Description = "Get All Comment In the Data Base by id",
            OperationId = "GetAllComment"
        )]
        [SwaggerResponse(200, "Returned All Comment", typeof(IEnumerable<CommentResource>))]
        [ProducesResponseType(typeof(IEnumerable<CommentResource>), 200)]
        [Produces("application/json")]
        public async Task<IEnumerable<CommentResource>> GetAllAsync()
        {
            var comments = await _commentservice.ListAsync();
            var resources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);
            return resources;
        }

        [HttpPost("{commentId}/tutors/{tutorId}")]
        [SwaggerOperation(
            Summary = "Assign comment to user",
            Description = "Assign comment to user by commentId and userId",
            OperationId = "AssignComment"
        )]
        [SwaggerResponse(200, "language user Assigned", typeof(CommentResource))]
        [ProducesResponseType(typeof(CommentResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> AssignUserLanguage(int tutorId, int commentId)
        {
            var result = await _commentservice.AssignComment(tutorId, commentId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var comment = await _commentservice.GetById(result.Resource.Id);
            var commentResource = _mapper.Map<Comment, CommentResource>(comment.Resource);
            return Ok(commentResource);
        }

        [HttpDelete("{commentId}/tutors/{tutorId}")]
        [SwaggerOperation(
            Summary = "Unassign comment to user",
            Description = "Unassign comment to user by commentId and userId",
            OperationId = "UnaassignComment"
        )]
        [SwaggerResponse(200, "language user Assigned", typeof(CommentResource))]
        [ProducesResponseType(typeof(CommentResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> UnassignUserLanguage(int tutorId, int commentId)
        {
            var result = await _commentservice.UnassignComment(tutorId, commentId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var comment = await _commentservice.GetById(result.Resource.Id);
            var commentResource = _mapper.Map<Comment, CommentResource>(comment.Resource);
            return Ok(commentResource);
        }
    }
}