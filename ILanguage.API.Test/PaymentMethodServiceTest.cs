using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Services;
using Moq;
using NUnit.Framework;

namespace ILanguage.API.Test
{
    public class PaymentMethodServiceTest
    {
        [Test]
        public async Task GetAllByUserIdWhenNoPaymentMethodsReturnsEmptyCollection()
        {
            var mockPaymentMethodRepository = GetDefaultIPaymentMethodRepositoryInterface();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var userId = 3;
            mockPaymentMethodRepository.Setup(r => r.ListByUserId(userId)).ReturnsAsync(new List<PaymentMethod>());
            var service = new PaymentMethodService(mockPaymentMethodRepository.Object, mockUnitOfWork.Object);

            List<PaymentMethod> result = (List<PaymentMethod>) await service.ListByUserId(userId);
            var paymentMethodsCount = result.Count;

            paymentMethodsCount.Should().Be(0);
        }
        


        private Mock<IPaymentMethodRepository> GetDefaultIPaymentMethodRepositoryInterface()
        {
            return new Mock<IPaymentMethodRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}