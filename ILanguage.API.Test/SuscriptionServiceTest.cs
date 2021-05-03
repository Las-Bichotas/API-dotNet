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
            mockSuscriuptionRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Suscription>());
            var service = new SuscriptionService(mockSuscriuptionRepository.Object, mockUnitOfWork.Object);

            List<Suscription> result = (List<Suscription>) await service.ListAsync();
            var suscriptionsCount = result.Count;

            suscriptionsCount.Should().Equals(0);
        }


        [Test]
        public async Task GetByIdAsyncWhenInvalidReturnsSuscriptionNotFoundResponse()
        {
            var mockSuscriptionRepository = GetDefaultISuscriptionRepositoryInterface();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();
            var suscriptionId = 14;
            mockSuscriptionRepository.Setup(r => r.FindById(suscriptionId)).Returns(Task.FromResult<Suscription>(null));
            var service = new SuscriptionService(mockSuscriptionRepository.Object, mockUnitOfWork.Object);

            SuscriptionResponse result = await service.GetById(suscriptionId);
            var message = result.Message;

            message.Should().Be("Suscription Not Found");
        }
        


        private Mock<ISuscriptionRepository> GetDefaultISuscriptionRepositoryInterface()
        {
            return new Mock<ISuscriptionRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstace()
        {
            return new Mock<IUnitOfWork>();
        }
    }
    
}