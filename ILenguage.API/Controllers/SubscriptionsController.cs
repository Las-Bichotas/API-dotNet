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
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IMapper _mapper;

        public SubscriptionsController(ISubscriptionService subscriptionService, IMapper mapper)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SuscriptionResource>), 200)]
        public async Task<IEnumerable<SuscriptionResource>> GetAllAsync()
        {
            var suscriptions = await _subscriptionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Subscription>, IEnumerable<SuscriptionResource>>(suscriptions);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SuscriptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _subscriptionService.GetById(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Subscription, SuscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSuscriptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var suscription = _mapper.Map<SaveSuscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.SaveAsync(suscription);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Subscription, SuscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(SuscriptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var result = await _subscriptionService.GetByName(name);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Subscription, SuscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }

        [HttpGet("{duration}")]
        [ProducesResponseType(typeof(SuscriptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetByDurationAsync(int duration)
        {
            var result = await _subscriptionService.GetByDuration(duration);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Subscription, SuscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSuscriptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var suscription = _mapper.Map<SaveSuscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.UpdateAsync(id, suscription);

            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Subscription, SuscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _subscriptionService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Subscription, SuscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }


    }
}