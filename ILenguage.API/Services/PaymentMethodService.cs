using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;

namespace ILenguage.API.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository, IUnitOfWork unitOfWork)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PaymentMethod>> ListByUserId(int userId)
        {
            var paymetMethod = await _paymentMethodRepository.ListByUserId(userId);
            return paymetMethod;
        }

        public async Task<PaymentMethodResponse> SaveAsync(PaymentMethod paymentMethod)
        {
            try
            {
                await _paymentMethodRepository.AddAsync(paymentMethod);
                await _unitOfWork.CompleteAsync();
                return new PaymentMethodResponse(paymentMethod);
            }
            catch (Exception e)
            {
                return new PaymentMethodResponse($"An error occurred while saving the Payment Method {e.Message}");
            }
        }

        public async Task<PaymentMethodResponse> UpdateAsync(int id, PaymentMethod paymentMethod)
        {
            var existingPaymentMethod = await _paymentMethodRepository.FindById(id);
            if (existingPaymentMethod == null)
                return new PaymentMethodResponse("Payment Method Not Found");
            existingPaymentMethod.month = paymentMethod.month;
            existingPaymentMethod.CardNumber = paymentMethod.CardNumber;
            existingPaymentMethod.CvcCode = paymentMethod.CvcCode;
            existingPaymentMethod.OwnerName = paymentMethod.OwnerName;
            existingPaymentMethod.PaymentNetwork = paymentMethod.PaymentNetwork;
            existingPaymentMethod.Year = paymentMethod.Year;
            try
            {
                _paymentMethodRepository.UpdateAsync(existingPaymentMethod);
                await _unitOfWork.CompleteAsync();
                return new PaymentMethodResponse(existingPaymentMethod);
            }
            catch (Exception e)
            {
                return new PaymentMethodResponse($"An error ocurred while saving the tag {e.Message}");
            }
        }

        public async Task<PaymentMethodResponse> Delete(int id)
        {
            var existingPaymentMethod = await _paymentMethodRepository.FindById(id);
            if (existingPaymentMethod == null)
                return new PaymentMethodResponse("PaymentMethod Not Found");
            try
            {
                _paymentMethodRepository.RemoveAsync(existingPaymentMethod);
                await _unitOfWork.CompleteAsync();
                return new PaymentMethodResponse(existingPaymentMethod);
            }
            catch (Exception e)
            {
                return new PaymentMethodResponse($"An error ocurred while deleting Payment Method {e.Message}");
            }
        }
    }
}