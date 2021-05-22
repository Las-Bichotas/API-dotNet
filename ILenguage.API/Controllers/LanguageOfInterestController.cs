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
    public class LanguageOfInterestController : ControllerBase
    {
        private readonly ILanguageOfInterestService _languageOfInterestService;
        private readonly IMapper _mapper;

        public LanguageOfInterestController(ILanguageOfInterestService languageOfInterestService, IMapper mapper)
        {
            _languageOfInterestService = languageOfInterestService;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Add new language",
            Description = "Add new language with initial data",
            OperationId = "Addlanguage"
        )]
        [SwaggerResponse(200, "Language Added", typeof(LanguageOfInterestResource))]
        [ProducesResponseType(typeof(LanguageOfInterestResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PostAsync([FromBody] SaveLanguageOfInterestResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var language = _mapper.Map<SaveLanguageOfInterestResource, LanguageOfInterest>(resource);
            var result = await _languageOfInterestService.SaveAsync(language);
            if (!result.Succes)
                return BadRequest(result.Message);
            var languageResource = _mapper.Map<LanguageOfInterest, LanguageOfInterestResource>(result.Resource);
            return Ok(languageResource);
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All languages",
            Description = "Get All languages In the Data Base",
            OperationId = "GetAllLanguages"
        )]
        [SwaggerResponse(200, "Returned languages", typeof(IEnumerable<LanguageOfInterestResource>))]
        [ProducesResponseType(typeof(IEnumerable<LanguageOfInterestResource>), 200)]
        [Produces("application/json")]
        public async Task<IEnumerable<LanguageOfInterestResource>> GetAllAsync()
        {
            var languages = await _languageOfInterestService.ListAsync();
            var resources = _mapper.Map<IEnumerable<LanguageOfInterest>, IEnumerable<LanguageOfInterestResource>>(languages);
            return resources;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get language",
            Description = "Get languages by language id",
            OperationId = "GetLanguageById"
        )]
        [SwaggerResponse(200, "Returned language", typeof(LanguageOfInterestResource))]
        [ProducesResponseType(typeof(LanguageOfInterestResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _languageOfInterestService.GetByIdAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            var languageResource = _mapper.Map<LanguageOfInterest, LanguageOfInterestResource>(result.Resource);
            return Ok(languageResource);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "delete language",
            Description = "delete languages by language id",
            OperationId = "deleteLanguageById"
        )]
        [SwaggerResponse(200, "Deleted language", typeof(LanguageOfInterestResource))]
        [ProducesResponseType(typeof(LanguageOfInterestResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _languageOfInterestService.DeleteAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);
            var languageResource = _mapper.Map<LanguageOfInterest, LanguageOfInterestResource>(result.Resource);

            return Ok(languageResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "update language",
            Description = "updated languages by language id",
            OperationId = "updatedLanguageById"
        )]
        [SwaggerResponse(200, "updated language", typeof(LanguageOfInterestResource))]
        [ProducesResponseType(typeof(LanguageOfInterestResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatedAsync(int id, [FromBody] SaveLanguageOfInterestResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var language = _mapper.Map<SaveLanguageOfInterestResource, LanguageOfInterest>(resource);
            var result = await _languageOfInterestService.UpdateAsync(id, language);

            if (!result.Succes)
                return BadRequest(result.Message);

            var languageResource = _mapper.Map<LanguageOfInterest, LanguageOfInterestResource>(result.Resource);
            return Ok(languageResource);
        }
    }

}