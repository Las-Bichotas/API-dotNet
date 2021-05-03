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
    public class RoleServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoRolesReturnsEmptyCollection()
        {
            var mockRoleRepository = GetDefaultIRoleRepositoryInstance();
            mockRoleRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<Role>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new RoleService(
                mockRoleRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<Role> result = (List<Role>)await service.ListAsync();
            int rolesCount = result.Count;

            // Assert
            rolesCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsRoleNotFoundResponse()
        {
            // Arrange
            var mockRoleRepository = GetDefaultIRoleRepositoryInstance();
            var roleId = 1;
            mockRoleRepository.Setup(r => r.FindById(roleId))
                .Returns(Task.FromResult<Role>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new RoleService(mockRoleRepository.Object, mockUnitOfWork.Object);
            // Act
            RoleResponse result = await service.GetByIdAsync(roleId);
            var message = result.Message;
            // Assert
            message.Should().Be("Role not found");
        }

        private Mock<IRoleRepository> GetDefaultIRoleRepositoryInstance()
        {
            return new Mock<IRoleRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}