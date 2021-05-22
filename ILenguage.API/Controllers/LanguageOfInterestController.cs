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

    }
}