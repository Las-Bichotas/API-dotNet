using ILanguage.API.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ILanguage.API.Domain.Models;
using ILanguage.API.Services;
using ILanguage.API.Domain.Services.Communication;

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