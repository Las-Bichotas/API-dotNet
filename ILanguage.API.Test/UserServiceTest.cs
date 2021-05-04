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
    {
        [Test]
        public async Task GetALlAsync_WhenNoUser_ReturnsEmptyCollection()
        {
            //Arrange
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            mockUserRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<User>());
            var service = new UserService(mockUserRepository.Object, mockUnitOfWork.Object);
            //Act
            List<User> result = (List<User>)await service.ListAsync();
            var UsersCount = result.Count;
            //Assert
            UsersCount.Should().Equals(0);
        }

        private Mock<IUserRepository> GetDefaultIUserRepositoryInstance()
        {
            return new Mock<IUserRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}