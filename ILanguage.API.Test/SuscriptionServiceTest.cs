using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using NUnit.Framework;

namespace ILanguage.API.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoSuscriptionsReturnsEmptyCollection()
        {
            var mockSuscriuptionRepository = GetDefaultISuscriptionRepositoryInterface();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();
            mockSuscriuptionRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Subscription>());
            var service = new SubscriptionService(mockSuscriuptionRepository.Object, mockUnitOfWork.Object);

            List<Subscription> result = (List<Subscription>) await service.ListAsync();
            var suscriptionsCount = result.Count;

            suscriptionsCount.Should().Equals(0);
        }


        [Test]
        public async Task GetByIdAsyncWhenInvalidReturnsSuscriptionNotFoundResponse()
        {
            var mockSuscriptionRepository = GetDefaultISuscriptionRepositoryInterface();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();
            var suscriptionId = 14;
            mockSuscriptionRepository.Setup(r => r.FindById(suscriptionId)).Returns(Task.FromResult<Subscription>(null));
            var service = new SubscriptionService(mockSuscriptionRepository.Object, mockUnitOfWork.Object);

            SubscriptionResponse result = await service.GetById(suscriptionId);
            var message = result.Message;

            message.Should().Be("Suscription Not Found");
        }
        


        private Mock<ISubscriptionRepository> GetDefaultISuscriptionRepositoryInterface()
        {
            return new Mock<ISubscriptionRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstace()
        {
            return new Mock<IUnitOfWork>();
        }
        
        
    }
    
}