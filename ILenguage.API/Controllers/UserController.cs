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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUserTopicService _userTopicService;
        private readonly ICommentService _commentService;

        public UserController(IUserService userService, IMapper mapper, IUserTopicService userTopicService, ICommentService commentService)
        {
            _userService = userService;
            _mapper = mapper;
            _userTopicService = userTopicService;
            _commentService = commentService;
        }
        [HttpGet("{tutorId}/comments")]
        public async Task<IEnumerable<CommentResource>> GetAllComments(int tutorId)
        {
            var comments = await _commentService.ListByTutorId(tutorId);
            var resources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);
            return resources;
        }
        [HttpPost("{roleId}")]
        [SwaggerOperation(
            Summary = "Add new user",
            Description = "Add new user with initial data",
            OperationId = "AddUser"
        )]
        [SwaggerResponse(200, "User Added", typeof(UserResource))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PostAsync(int roleId, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.SaveAsync(user, roleId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }
        [HttpGet("/api/languages/{languageId}/topics/{topicId}/tuthors")]
        [SwaggerOperation(
            Summary = "Get All Users By Languages Id And Topic Id",
            Description = "Get All Users by languages id and topic Id",
            OperationId = "GetAllUsersByLanguageIdAndTopicId"
        )]
        [SwaggerResponse(200, "Users Returned", typeof(IEnumerable<UserResource>))]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IEnumerable<UserResource>> GetAllUserByLanguaguesIdAndTopicId(int languageId, int topicId)
        {
            var users = await _userService.ListTuthorsByLanguageIdAndTopicId(languageId, topicId);
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All Users",
            Description = "Get All Users In The Data Base",
            OperationId = "GetAllUsers"
        )]
        [SwaggerResponse(200, "Users Returned", typeof(IEnumerable<UserResource>))]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }

        [HttpGet("/role/{roleId}/users")]
        [SwaggerOperation(
            Summary = "Get All Users By Role Id",
            Description = "Get All Users by role Id",
            OperationId = "GetAllUsersByRoleId"
        )]
        [SwaggerResponse(200, "Users Returned", typeof(IEnumerable<UserResource>))]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IEnumerable<UserResource>> GetAllUsersByRoleId(int roleId)
        {
            var users = await _userService.ListByRoleId(roleId);
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete User",
            Description = "Delete User By User Id",
            OperationId = "DeleteUserById"
        )]
        [SwaggerResponse(200, "User Deleted", typeof(UserResource))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);

            return Ok(userResource);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get User",
            Description = "Get User By User Id",
            OperationId = "GetlUserById"
        )]
        [SwaggerResponse(200, "User Returned", typeof(UserResource))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _userService.GetByIdAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        [HttpPost("/login")]
        [SwaggerOperation(
            Summary = "Login",
            Description = "Get User By User Email and User Password",
            OperationId = "GetlUserByEmailAndPassword"
        )]
        [SwaggerResponse(200, "User Returned", typeof(UserResource))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserForLoginAsync([FromBody] SaveLoginResource resource)
        {
            var result = await _userService.GetByEmailAndPasswordAsync(resource.Email, resource.Password);

            if (!result.Succes)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update User",
            Description = "Update User By User Id",
            OperationId = "UpdateUserById"
        )]
        [SwaggerResponse(200, "User Updated", typeof(UserResource))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.UpdateAsync(id, user);

            if (!result.Succes)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }


        /*****************************************************************************/
        /*

        [HttpGet("sessions/{sessionId}")]
        [SwaggerOperation(
         Summary = "List Users by SessionId",
         Description = "List Users By SessionId",
         OperationId = "UsersBySessionId"
        )]
        [SwaggerResponse(200, "Users Returned", typeof(UserResource))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IEnumerable<UserResource>> GetAllBySessionIdAsync(int sessionId)
        {
            var users = await _userService.ListBySessionIdAsync(sessionId);
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

            return resources;
        }


        [HttpPost("sessions/{sessionId}")]
        [SwaggerOperation(
        Summary = "Assign users to Session",
        Description = "Assign User By SessionId",
        OperationId = "AssignUserBySessionId"
        )]
        [SwaggerResponse(200, "Users Assigned", typeof(UserResource))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> AssignUsersSession(int sessionId, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var user = await _userService.GetByIdAsync(userId);
            var result = await _userService.AssignUserSession(user.Resource, sessionId);

            if (!result.Succes)
                return BadRequest(result.Message);


            return Ok(result.Resource);
        }*/

    }
}