using FluentAssertions;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services.Communications;
using ILenguage.API.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILanguage.API.Test
{
    public class SessionDetailServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoSessionDetailsReturnsEmptyCollection()
        {
            var mockSessionDetailRepository = GetDefaultISessionDetailRepositoryInstance();
            mockSessionDetailRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<SessionDetail>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new SessionDetailService(
                mockSessionDetailRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<SessionDetail> result = (List<SessionDetail>)await service.ListAsync();
            int sessionDetailssCount = result.Count;

            // Assert
            sessionDetailssCount.Should().Equals(0);
        }

       
        private Mock<ISessionDetailRepository> GetDefaultISessionDetailRepositoryInstance()
        {
            return new Mock<ISessionDetailRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}