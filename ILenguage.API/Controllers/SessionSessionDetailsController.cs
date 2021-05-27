using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services;
using ILenguage.API.Extensions;
using ILenguage.API.Resources;
using ILenguage.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Controllers
{
    [Route("/api/sessions/{sessionId}/session-details")]
    public class SessionSessionDetailsController : ControllerBase
    {
        private ISessionDetailService _sessionDetailService;
        private readonly IMapper _mapper;

        public SessionSessionDetailsController(ISessionDetailService sessionDetailService, IMapper mapper)
        {
            _sessionDetailService = sessionDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SessionDetailResource>> GetAllBySessionIdAsync(int sessionId)
        {
            var sessionDetails = await _sessionDetailService.ListBySessionIdAsync(sessionId);
            var resources = _mapper.Map<IEnumerable<SessionDetail>, IEnumerable<SessionDetailResource>>(sessionDetails);

            return resources;
        }
        /*
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSessionDetailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var sesionDetail = _mapper.Map<SaveSessionDetailResource, SessionDetail>(resource);
            var result = await _sessionDetailService.SaveAsync(sesionDetail);

            if (!result.Succes)
                return BadRequest(result.Message);

            var benefitResource = _mapper.Map<SessionDetail, SessionDetailResource>(result.Resource);

            return Ok(benefitResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSessionDetailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var sessionDetail = _mapper.Map<SaveSessionDetailResource, SessionDetail>(resource);
            var result = await _sessionDetailService.UpdateAsync(id, sessionDetail);

            if (!result.Succes)
                return BadRequest(result.Message);

            var benefitResource = _mapper.Map<SessionDetail, SessionDetailResource>(result.Resource);

            return Ok(benefitResource);

        }
        */
    }
}
