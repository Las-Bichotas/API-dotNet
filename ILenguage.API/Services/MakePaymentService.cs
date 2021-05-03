using System;
using System.Threading.Tasks;
using ILenguage.API.Domain.Services;
using Stripe;

namespace ILenguage.API.Services
{
    public class MakePaymentService : IMakePaymentService
    {
        public  async Task<dynamic> PayAsync(string cardNumber, int month, int year, string cvc, long? value )
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51In4wPE2tZxbkTDU8qHWb8ccuq8uyd3Gnf4vqXmX3yXayADLjuo8dmk8K8NwbsnoKhbx083xtB7fLnb4QJzdvpkd00SRVjc3vl";
                var optionsToken = new PaymentMethodCreateOptions
                {
                    Type = "card",
                    Card = new PaymentMethodCardOptions
                    {
                        Number = cardNumber,
                        ExpMonth = month,
                        ExpYear = year,
                        Cvc = cvc,
                        
                    },
                };

                var options = new ChargeCreateOptions
               {
                   Amount = value,
                   Currency = "usd",
                   Description = "test",
                   Source = "tok_amex",
               };
                var service = new PaymentMethodService();
                await service.CreateAsync(optionsToken);
                return service;
            }
            catch (Exception e)
            {
                return $"An error ocurred with the transaction {e.Message}";
            }
        }


       
    }
}