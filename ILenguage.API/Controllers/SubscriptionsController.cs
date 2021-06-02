using System.Collections;
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
        [SwaggerOperation(
            Summary = "Get all subscriptions",
            Description = "Get all subscription available",
            OperationId = "GetSubscriptions"
        )]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IEnumerable<SubscriptionResource>> GetAllAsync()
        {
            var suscriptions = await _subscriptionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Subscription>, IEnumerable<SubscriptionResource>>(suscriptions);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SubscriptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [SwaggerOperation(
            Summary = "Get subscription by Id",
            Description = "Get a subscription only if it exists in the database",
            OperationId = "GetSubscriptionById"
        )]
        [SwaggerResponse(200, "Subscription Found", typeof(SubscriptionResource))]
        [SwaggerResponse(404, "Subscription not found", typeof(SubscriptionResource))]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _subscriptionService.GetById(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Add new subscription",
            Description = "Add new subscription with initial data",
            OperationId = "AddSubscription"
        )]
        public async Task<IActionResult> PostAsync([FromBody] SaveSuscriptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var suscription = _mapper.Map<SaveSuscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.SaveAsync(suscription);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }

        [HttpGet("name/{name}")]
        [ProducesResponseType(typeof(SubscriptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [SwaggerOperation(
            Summary = "Get subscription by Name",
            Description = "Get a subscription only if it exists in the database",
            OperationId = "GetSubscriptionByName"
        )]
        [SwaggerResponse(200, "Subscription Found", typeof(SubscriptionResource))]
        [SwaggerResponse(404, "Subscription not found", typeof(SubscriptionResource))]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var result = await _subscriptionService.GetByName(name);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }

        [HttpGet("duration/{duration}")]
        [ProducesResponseType(typeof(SubscriptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [SwaggerOperation(
            Summary = "Get subscription by Duration",
            Description = "Get a subscription only if it exists in the database",
            OperationId = "GetSubscriptionByDuration"
        )]
        [SwaggerResponse(200, "Subscription Found", typeof(SubscriptionResource))]
        [SwaggerResponse(404, "Subscription not found", typeof(SubscriptionResource))]
        public async Task<IActionResult> GetByDurationAsync(int duration)
        {
            var result = await _subscriptionService.GetByDuration(duration);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Subscription",
            Description = "Update Subscription By Subscription Id",
            OperationId = "UpdateSubscriptionById"
        )]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSuscriptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var suscription = _mapper.Map<SaveSuscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.UpdateAsync(id, suscription);

            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete Subscription",
            Description = "Delete Subscription By Subscription Id",
            OperationId = "DeleteSubscriptionById"
        )]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _subscriptionService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var suscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(suscriptionResource);
        }


    }
}
