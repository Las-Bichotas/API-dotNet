using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services;
using ILenguage.API.Resources;
using ILenguage.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ILenguage.API.Controllers
{
    [Route("/api/sessions/{sessionId}/session-details")]
    public class SessionDetailsController : ControllerBase
    {
        private readonly ISessionDetailService _sessionDetailService;
        private readonly IMapper _mapper;

        public SessionDetailsController(ISessionDetailService sessionDetailService, IMapper mapper)
        {
            _sessionDetailService = sessionDetailService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all sessionsDetails",
            Description = "List of sessionsDetails",
            OperationId = "ListAllSessionsDetails"
            )]
        [SwaggerResponse(200, "List of SessionDetails", typeof(IEnumerable<SessionDetailResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SessionDetailResource>), 200)]
        public async Task<IEnumerable<SessionDetailResource>> GetAllAsync()
        {
            var sessionDetails = await _sessionDetailService.ListAsync();
            var resources = _mapper.Map<IEnumerable<SessionDetail>, IEnumerable<SessionDetailResource>>(sessionDetails);
            return resources;
        }


        [HttpGet("{id}")]
        [SwaggerOperation(
          Summary = "Get SessionDetail",
          Description = "Get SessionDetail By Session Id",
          OperationId = "GetSessionDetailBySessionId"
        )]
        [SwaggerResponse(200, "Session Detail Returned", typeof(SessionDetailResource))]
        [ProducesResponseType(typeof(SessionDetailResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IEnumerable<SessionDetailResource>> GetAllBySessionIdAsync(int sessionId)
        {
            var sessionDetails = await _sessionDetailService.ListBySessionIdAsync(sessionId);
            var resources = _mapper.Map<IEnumerable<SessionDetail>, IEnumerable<SessionDetailResource>>(sessionDetails);

            return resources;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Add new sessionDetail",
            Description = "Add new sessionDetail",
            OperationId = "AddSessionDetail"
        )]
        [SwaggerResponse(200, "SessionDetail Added", typeof(SessionDetailResource))]
        [ProducesResponseType(typeof(SessionDetailResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PostAsync([FromBody] SaveSessionDetailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var sesionDetail = _mapper.Map<SaveSessionDetailResource, SessionDetail>(resource);
            var result = await _sessionDetailService.SaveAsync(sesionDetail);

            if (!result.Succes)
                return BadRequest(result.Message);

            var sesionDetailResource = _mapper.Map<SessionDetail, SessionDetailResource>(result.Resource);

            return Ok(sesionDetailResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update SessionDetail",
            Description = "Update SessionDetail By Id",
            OperationId = "UpdateSessionDetailById"
        )]
        [SwaggerResponse(200, "SessionDetail Updated", typeof(SessionDetailResource))]
        [ProducesResponseType(typeof(SessionDetailResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSessionDetailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var sessionDetail = _mapper.Map<SaveSessionDetailResource, SessionDetail>(resource);
            var result = await _sessionDetailService.UpdateAsync(id, sessionDetail);

            if (!result.Succes)
                return BadRequest(result.Message);

            var sessionDetailResource = _mapper.Map<SessionDetail, SessionDetailResource>(result.Resource);

            return Ok(sessionDetailResource);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Delete SessionDetail",
           Description = "Delete SessionDetail By Session Id",
           OperationId = "DeleteSessionDetailById"
       )]
        [SwaggerResponse(200, "SessionDetail Deleted", typeof(SessionDetailResource))]
        [ProducesResponseType(typeof(SessionDetailResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _sessionDetailService.DeleteAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            var sessionDetailResource = _mapper.Map<SessionDetail, SessionDetailResource>(result.Resource);

            return Ok(sessionDetailResource);

        }
    }
}
