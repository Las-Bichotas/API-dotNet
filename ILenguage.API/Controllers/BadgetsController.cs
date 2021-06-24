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
    public class BadgetsController : ControllerBase
    {
        private readonly IBadgetService _badgetsService;
        private readonly IMapper _mapper;

        public BadgetsController(IBadgetService badgetsService, IMapper mapper)
        {
            _badgetsService = badgetsService;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Add new Badget",
            Description = "Add new Badget with initial data",
            OperationId = "AddBadget"
        )]
        [SwaggerResponse(200, "Badget Added", typeof(BadgetsResource))]
        [ProducesResponseType(typeof(BadgetsResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PostAsync([FromBody] SaveBadgetsResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var badget = _mapper.Map<SaveBadgetsResource, Badgets>(resource);
            var result = await _badgetsService.SaveAsync(badget);
            if (!result.Succes)
                return BadRequest(result.Message);
            var badgetResource = _mapper.Map<Badgets, BadgetsResource>(result.Resource);
            return Ok(badgetResource);
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All badgets",
            Description = "Get All badgets In the Data Base",
            OperationId = "GetAllBadgets"
        )]
        [SwaggerResponse(200, "Returned Badgets", typeof(BadgetsResource))]
        [ProducesResponseType(typeof(BadgetsResource), 200)]
        [Produces("application/json")]
        public async Task<IEnumerable<BadgetsResource>> GetAllAsync()
        {
            var badgets = await _badgetsService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Badgets>, IEnumerable<BadgetsResource>>(badgets);
            return resources;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get badget",
            Description = "Get badget by badget id",
            OperationId = "GetBadgetById"
        )]
        [SwaggerResponse(200, "Returned Badget", typeof(BadgetsResource))]
        [ProducesResponseType(typeof(BadgetsResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _badgetsService.GetByIdAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            var badgetResource = _mapper.Map<Badgets, BadgetsResource>(result.Resource);
            return Ok(badgetResource);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "delete badget",
            Description = "delete badget by badget id",
            OperationId = "deleteBadgetById"
        )]
        [SwaggerResponse(200, "Deleted badget", typeof(BadgetsResource))]
        [ProducesResponseType(typeof(BadgetsResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _badgetsService.DeleteAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            var badgetResource = _mapper.Map<Badgets, BadgetsResource>(result.Resource);

            return Ok(badgetResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "update Badget",
            Description = "updated Badgets by badget id",
            OperationId = "updatedBadgetById"
        )]
        [SwaggerResponse(200, "updated badget", typeof(BadgetsResource))]
        [ProducesResponseType(typeof(BadgetsResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatedAsync(int id, [FromBody] SaveBadgetsResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var badget = _mapper.Map<SaveBadgetsResource, Badgets>(resource);
            var result = await _badgetsService.UpdateAsync(id, badget);
            if (!result.Succes)
                return BadRequest(result.Message);
            var badgetResource = _mapper.Map<Badgets, BadgetsResource>(result.Resource);
            return Ok(badgetResource);
        }
    }
}