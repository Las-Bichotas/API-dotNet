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
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SessionDetailsController : ControllerBase
    {
        private readonly ISessionDetailService _sessionDatailService;
        private readonly IMapper _mapper;

        public SessionDetailsController(ISessionDetailService sessionDetailService, IMapper mapper)
        {
            _sessionDatailService = sessionDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SessionDetailResource>> GetAllAsync()
        {
            var sessionDetails = await _sessionDatailService.ListAsync();
            var resources = _mapper.Map<IEnumerable<SessionDetail>, IEnumerable<SessionDetailResource>>(sessionDetails);
            return resources;
        }
    }
}
