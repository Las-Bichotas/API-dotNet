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
using ILenguage.API.Extensions;

namespace ILenguage.API.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public SessionsController(ISessionService sessionService, IMapper mapper)
        {
            _sessionService = sessionService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all sessions",
            Description = "List of sessions",
            OperationId = "ListAllSessions"
            )]
        [SwaggerResponse(200, "List of Sessions", typeof(IEnumerable<SessionResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SessionResource>), 200)]
        public async Task<IEnumerable<SessionResource>> GetAllAsync()
        {
            var sessions = await _sessionService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Session>, IEnumerable<SessionResource>>(sessions);

            return resources;

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get Session",
            Description = "Get Session By Session Id",
            OperationId = "GetSessionById"
        )]
        [SwaggerResponse(200, "Session Returned", typeof(SessionResource))]
        [ProducesResponseType(typeof(SessionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _sessionService.GetByIdAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            var sessionResource = _mapper.Map<Session, SessionResource>(result.Resource);

            return Ok(sessionResource);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Add new session",
            Description = "Add new session with initial data",
            OperationId = "AddSession"
        )]
        [SwaggerResponse(200, "Session Added", typeof(SessionResource))]
        [ProducesResponseType(typeof(SessionResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PostAsync([FromBody] SaveSessionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var session = _mapper.Map<SaveSessionResource, Session>(resource);
            var result = await _sessionService.SaveAsync(session);

            if (!result.Succes)
                return BadRequest(result.Message);

            var sessionResource = _mapper.Map<Session, SessionResource>(result.Resource);

            return Ok(sessionResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Session",
            Description = "Update Session By Session Id",
            OperationId = "UpdateSessionById"
        )]
        [SwaggerResponse(200, "Session Updated", typeof(SessionResource))]
        [ProducesResponseType(typeof(SessionResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSessionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var session = _mapper.Map<SaveSessionResource, Session>(resource);
            var result = await _sessionService.UpdateAsync(id, session);

            if (!result.Succes)
                return BadRequest(result.Message);

            var sessionResource = _mapper.Map<Session, SessionResource>(result.Resource);

            return Ok(sessionResource);

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete Session",
            Description = "Delete Session By Session Id",
            OperationId = "DeleteSessionById"
        )]
        [SwaggerResponse(200, "Session Deleted", typeof(SessionResource))]
        [ProducesResponseType(typeof(SessionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _sessionService.DeleteAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            var sessionResource = _mapper.Map<Session, SessionResource>(result.Resource);

            return Ok(sessionResource);

        }

    }
}
