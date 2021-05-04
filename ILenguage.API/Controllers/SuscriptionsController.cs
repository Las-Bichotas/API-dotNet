using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services;
using ILenguage.API.Extensions;
using ILenguage.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace ILenguage.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class SuscriptionsController : ControllerBase
    {
        private readonly ISuscriptionService _suscriptionService;
        private readonly IMapper _mapper;

        public SuscriptionsController(ISuscriptionService suscriptionService, IMapper mapper)
        {
            _suscriptionService = suscriptionService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SuscriptionResource>), 200)]
        public async Task<IEnumerable<SuscriptionResource>> GetAllAsync()
        {
            var suscriptions = await _suscriptionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Suscription>, IEnumerable<SuscriptionResource>>(suscriptions);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SuscriptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _suscriptionService.GetById(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Suscription, SuscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSuscriptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var suscription = _mapper.Map<SaveSuscriptionResource, Suscription>(resource);
            var result = await _suscriptionService.SaveAsync(suscription);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Suscription, SuscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(SuscriptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var result = await _suscriptionService.GetByName(name);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Suscription, SuscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }

        [HttpGet("{duration}")]
        [ProducesResponseType(typeof(SuscriptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetByDurationAsync(int duration)
        {
            var result = await _suscriptionService.GetByDuration(duration);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Suscription, SuscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSuscriptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var suscription = _mapper.Map<SaveSuscriptionResource, Suscription>(resource);
            var result = await _suscriptionService.UpdateAsync(id, suscription);

            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Suscription, SuscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _suscriptionService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Suscription, SuscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }


    }
}