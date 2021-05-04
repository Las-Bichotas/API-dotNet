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
    public class ScheduleServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsScheduleNotFoundResponse()
        {
            // Arrange
            var mockScheduleRepository = GetDefaultIScheduleRepositoryInstance();
            var ScheduleId = 1;
            mockScheduleRepository.Setup(r => r.FindById(ScheduleId))
                .Returns(Task.FromResult<Schedule>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new ScheduleService(mockScheduleRepository.Object, mockUnitOfWork.Object);
            // Act
            ScheduleResponse result = await service.GetByIdAsync(ScheduleId);
            var message = result.Message;
            // Assert
            message.Should().Be("Schedule not found");
        }

        private Mock<IScheduleRepository> GetDefaultIScheduleRepositoryInstance()
        {
            return new Mock<IScheduleRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}