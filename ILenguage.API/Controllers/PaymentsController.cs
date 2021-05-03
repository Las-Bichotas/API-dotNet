﻿using System.Threading.Tasks;
using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace ILenguage.API.Controllers
{
    
    [Microsoft.AspNetCore.Components.Route("/api/[controller")]
    [ApiController]
    public class PaymentsController : ControllerBase


    {
        private readonly IMakePaymentService _makePaymentService;
        private readonly IMapper _mapper;

        public PaymentsController(IMakePaymentService makePaymentService, IMapper mapper)
        {
            _makePaymentService = makePaymentService;
            _mapper = mapper;
        }

        [HttpPost("/pay")]
        public async Task<dynamic> pay(SavePaymentResource pm)
        {
            return  await _makePaymentService.PayAsync(pm.CardNumber, pm.Month, pm.Year, pm.Cvc, pm.Value);
            
        }

    }
}