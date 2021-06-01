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
    public class UserServiceTest
    {/*
        [Test]
        public async Task GetALlAsync_WhenNoUser_ReturnsEmptyCollection()
        {
            //Arrange
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockUserSubscriptionRepository = GetDefaultIUserSubscriptionRepositoryInstance();
            var mockUserScheduleRepository = GetDefaultIUserScheduleRepositoryInstance();
            mockUserRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<User>());
            var service = new UserService(mockUserRepository.Object, mockUnitOfWork.Object, mockUserSubscriptionRepository.Object, mockUserScheduleRepository.Object);
            //Act
            List<User> result = (List<User>)await service.ListAsync();
            var UsersCount = result.Count;
            //Assert
            UsersCount.Should().Equals(0);
        }

        [Test]
        public async Task GetAllAsync_WhenUserId_ReturnEmptyCollection()
        {

            //Arrange
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockUserSubscriptionRepository = GetDefaultIUserSubscriptionRepositoryInstance();
            var mockUserScheduleRepository = GetDefaultIUserScheduleRepositoryInstance();
            var userId = 1;
            mockUserRepository.Setup(r => r.FindById(userId)).Returns(Task.FromResult<User>(null));
            var service = new UserService(mockUserRepository.Object, mockUnitOfWork.Object, mockUserSubscriptionRepository.Object, mockUserScheduleRepository.Object);
            //Act
            UserResponse result = await service.GetByIdAsync(userId);
            var message = result.Message;
            //Assert
            message.Should().Be("User not found");
        }

        private Mock<IUserRepository> GetDefaultIUserRepositoryInstance()
        {
            return new Mock<IUserRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

        private Mock<IUserSubscriptionRepository> GetDefaultIUserSubscriptionRepositoryInstance()
        {
            return new Mock<IUserSubscriptionRepository>();
        }
        private Mock<IUserScheduleRepository> GetDefaultIUserScheduleRepositoryInstance()
        {
            return new Mock<IUserScheduleRepository>();
        }*/
    }
}