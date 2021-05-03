using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Extensions;
using ILenguage.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Controllers
{
    
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IMapper _mapper;

        public PaymentMethodsController(IPaymentMethodService paymentMethodService, IMapper mapper)
        {
            _paymentMethodService = paymentMethodService;
            _mapper = mapper;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _paymentMethodService.Delete(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var paymentMethodResource = _mapper.Map<PaymentMethod, PaymentMethodResource>(result.Resource);
            return Ok(paymentMethodResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePaymentMethodResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var paymentMethod = _mapper.Map<SavePaymentMethodResource, PaymentMethod>(resource);
            var result = await _paymentMethodService.UpdateAsync(id, paymentMethod);
            if (!result.Succes)
                return BadRequest(result.Message);
            var paymentResource = _mapper.Map<PaymentMethod, SuscriptionResource>(result.Resource);
            return Ok(paymentResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePaymentMethodResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var paymentMethod = _mapper.Map<SavePaymentMethodResource, PaymentMethod>(resource);
            var result = await _paymentMethodService.SaveAsync(paymentMethod);
            if (!result.Succes)
                return BadRequest(result.Message);
            var paymentMethodResource = _mapper.Map<PaymentMethod, PaymentMethodResource>(result.Resource);
            return Ok(paymentMethodResource);
        }


        [HttpGet("paymentMethod/{id}/user/{userId}")]
        [ProducesResponseType(typeof(IEnumerable<PaymentMethodResource>), 200)]
        public async Task<IEnumerable<PaymentMethodResource>> GetAllByUserIdAsync(int userId)
        {
            var paymentMethod = await _paymentMethodService.ListByUserId(userId);
            var resources = _mapper.Map<IEnumerable<PaymentMethod>, IEnumerable<PaymentMethodResource>>(paymentMethod);
            return resources;

        }
    }
} 