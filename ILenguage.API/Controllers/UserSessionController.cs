using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services;
using ILenguage.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;


namespace ILenguage.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/users/{userId}/sessions")]
    public class UserSessionController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISessionService _sessionService;
        private readonly IUserSessionService _userSessionService;
        private readonly IMapper _mapper;

        public UserSessionController(IUserService userService, ISessionService sessionService, IUserSessionService userSessionService, IMapper mapper)
        {
            _userService = userService;
            _sessionService = sessionService;
            _userSessionService = userSessionService;
            _mapper = mapper;
        }


        [HttpGet("/api/sessions/{sessionId}/users")]
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

        [HttpGet]
        [SwaggerOperation(
          Summary = "List Sessions by UserId",
          Description = "List Sessions By UserId",
          OperationId = "SessionsByUserId"
        )]
        [SwaggerResponse(200, "Sessions Returned", typeof(SessionResource))]
        [ProducesResponseType(typeof(SessionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IEnumerable<SessionResource>> GetAllByUserIdAsync(int userId)
        {
            var sessions = await _sessionService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<Session>, IEnumerable<SessionResource>>(sessions);

            return resources;
        }
        /*
        [HttpGet]
        [SwaggerOperation(
         Summary = "List Sessions by StudentId and TutorId",
         Description = "List Sessions By StudentId and TutorId",
         OperationId = "SessionsByStudentIdAndTutorId"
        )]
        [SwaggerResponse(200, "Sessions Returned", typeof(SessionResource))]
        [ProducesResponseType(typeof(SessionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IEnumerable<SessionResource>> GetAllByUserIdAsync(int studenId, int tutorId)
        {
            var userSessions = await _userSessionService.ListByStudentIdAndTutorIdAsync(studenId, tutorId);
            var resources = _mapper.Map<IEnumerable<Session>, IEnumerable<SessionResource>>(userSessions);

            return resources;
        }
        */

        [HttpPost("{sessionId}")]
        [SwaggerOperation(
        Summary = "Assign users to Session",
        Description = "Assign User to Session",
        OperationId = "AssignUserToSession"
        )]
        [SwaggerResponse(200, "User Assigned", typeof(UserResource))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> AssignUserSession(int userId, int sessionId)
        {
            var result = await _userSessionService.AssignUserSessionAsync(userId, sessionId);

            if (!result.Succes)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource.User);

            return Ok(userResource);
        }
        
        [HttpDelete("{sessionId}")]
        [SwaggerOperation(
        Summary = "Unassign users to Session",
        Description = "Unassign User to Session",
        OperationId = "UnassignUserToSession"
        )]
        [SwaggerResponse(200, "User Unssigned", typeof(UserResource))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> UnassignUserSession(int userId, int sessionId)
        {
            var result = await _userSessionService.UnassignUserSessionAsync(userId, sessionId);

            if (!result.Succes)
                return BadRequest(result.Message);

            var user = await _userService.GetByIdAsync(result.Resource.UserId);

            var userResource= _mapper.Map<User, UserResource>(user.Resource);
            return Ok(userResource);
        }
    }
}
