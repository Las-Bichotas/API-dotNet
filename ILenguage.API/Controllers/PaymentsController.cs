using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILenguage.API.Controllers
{
    
    [Microsoft.AspNetCore.Components.Route("/api/[controller")]
    [ApiController]
    public class PaymentsController : ControllerBase


    {
        private readonly IMakePaymentService _makePaymentService;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentsController(IMakePaymentService makePaymentService, IUnitOfWork unitOfWork)
        {
            _makePaymentService = makePaymentService;
            _unitOfWork = unitOfWork;
        }

        [Route("pay")]
        public async Task<dynamic> pay(Payment pm)
        {
            return  await _makePaymentService.PayAsync(pm.CardNumber, pm.Month, pm.Year, pm.Cvc, pm.Value);
            
        }

    }
}