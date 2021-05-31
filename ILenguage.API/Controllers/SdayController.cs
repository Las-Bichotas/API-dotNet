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
            var result = await _sdayService.GetByIdAsync(id);
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

        [HttpPost]
        [SwaggerOperation(
            Summary = "Add new day",
            Description = "Add new day with initial data",
            OperationId = "Addday"
        )]
        [SwaggerResponse(200, "Day Added", typeof(SdayResource))]
        [ProducesResponseType(typeof(SdayResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PostAsync([FromBody] SaveSdayResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var sday = _mapper.Map<SaveSdayResource, Sday>(resource);
            var result = await _sdayService.SaveAsync(sday);

            if (!result.Succes)
                return BadRequest(result.Message);

            var sdayResource = _mapper.Map<Sday, SdayResource>(result.Resource);

            return Ok(sdayResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Day",
            Description = "Update Day By Day Id",
            OperationId = "UpdateDayById"
        )]
        [SwaggerResponse(200, "Day Updated", typeof(SdayResource))]
        [ProducesResponseType(typeof(SdayResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSdayResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var sday = _mapper.Map<SaveSdayResource, Sday>(resource);
            var result = await _sdayService.UpdateAsync(id, sday);

            if (!result.Succes)
                return BadRequest(result.Message);

            var sdayResource = _mapper.Map<Sday, SdayResource>(result.Resource);

            return Ok(sdayResource);

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete Day",
            Description = "Delete Day By Day Id",
            OperationId = "DeleteDayById"
        )]
        [SwaggerResponse(200, "Day Deleted", typeof(SdayResource))]
        [ProducesResponseType(typeof(SdayResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _sdayService.DeleteAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            var sdayResource = _mapper.Map<Sday, SdayResource>(result.Resource);

            return Ok(sdayResource);

        }
        
        
    }
}