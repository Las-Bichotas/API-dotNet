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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentservice;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentservice, IMapper mapper)
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
    }
}