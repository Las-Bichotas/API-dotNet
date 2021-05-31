using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services;
using ILenguage.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ILenguage.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    
    [Route("api/[controller]")]
    public class SdayController : ControllerBase
    {
        private readonly ISdayService _sdayService;
        private readonly IMapper _mapper;
    

        public SdayController(ISdayService sdayService, IMapper mapper)
        {
            _sdayService = sdayService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SdayResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [SwaggerOperation(
            Summary = "Get Sday by Id",
            Description = "Get a day only if it exists in the database",
            OperationId = "GetSdayById"
        )]
        [SwaggerResponse(200, "Sday Found", typeof(SdayResource))]
        [SwaggerResponse(404, "Sday not found", typeof(SdayResource))]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _sdayService.GetById(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var sdayResource = _mapper.Map<Sday, SdayResource>(result.Resource);
            return Ok(sdayResource);
        }

        [HttpPost("{id}")]
        [SwaggerOperation(
            Summary = "Assing dat",
            Description="Assing day and save it on the Database",
            OperationId="AssingSday")]
        public async Task<IActionResult> AssingSday(int id)
        {
            var result = await _sdayService.AssingSdayAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var sdayResource = _mapper.Map<Sday, SdayResource>(result.Resource);
            return Ok(sdayResource);
        }

        
        
        
    }
}