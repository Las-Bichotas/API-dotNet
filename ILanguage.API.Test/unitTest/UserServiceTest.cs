using FluentAssertions;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Repositories;
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
            var mockUserSubscriptionRepository = GetDefaultIUserSubscriptionRepositoryInstance();
            var mockUserScheduleRepository = GetDefaultIUserScheduleRepositoryInstance();
            var mockIRoleRepository = GetDefaultIRoleRepositoryInstance();
            var mockIUserTopicRepository = GetDefaultIUserTopicRepositoryInstance();
            var mockIUserLanguageRepository = GetDefaultIUserLanguageRepositoryInstance();
            mockUserRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<User>());
            var service = new UserService(mockUserRepository.Object, mockUnitOfWork.Object, mockUserSubscriptionRepository.Object, mockUserScheduleRepository.Object, mockIRoleRepository.Object, mockIUserTopicRepository.Object, mockIUserLanguageRepository.Object);
            //Act
            List<User> result = (List<User>)await service.ListAsync();
            var UsersCount = result.Count;
            //Assert
            UsersCount.Should().Equals(0);
            Assert.That(UsersCount, Is.EqualTo(0));
        }

        [Test]
        public async Task GetAllAsync_WhenUserId_ReturnEmptyCollection()
        {

            //Arrange
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockUserSubscriptionRepository = GetDefaultIUserSubscriptionRepositoryInstance();
            var mockUserScheduleRepository = GetDefaultIUserScheduleRepositoryInstance();
            var mockIRoleRepository = GetDefaultIRoleRepositoryInstance();
            var mockIUserTopicRepository = GetDefaultIUserTopicRepositoryInstance();
            var mockIUserLanguageRepository = GetDefaultIUserLanguageRepositoryInstance();
            var userId = 1;
            mockUserRepository.Setup(r => r.FindById(userId)).Returns(Task.FromResult<User>(null));
            var service = new UserService(mockUserRepository.Object, mockUnitOfWork.Object, mockUserSubscriptionRepository.Object, mockUserScheduleRepository.Object, mockIRoleRepository.Object, mockIUserTopicRepository.Object, mockIUserLanguageRepository.Object);

            //Act
            UserResponse result = await service.GetByIdAsync(userId);
            var message = result.Message;
            //Assert
            message.Should().Be("User not found");
            Assert.That(message, Is.EqualTo("User not found"));
        }
        [Test]
        public async Task GetTuthorsAsync_WhenNoUserWithTopicOrLanguageAsync_ReturnEmptyCollection()
        {
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockUserSubscriptionRepository = GetDefaultIUserSubscriptionRepositoryInstance();
            var mockUserScheduleRepository = GetDefaultIUserScheduleRepositoryInstance();
            var mockIRoleRepository = GetDefaultIRoleRepositoryInstance();
            var mockIUserTopicRepository = GetDefaultIUserTopicRepositoryInstance();
            var mockIUserLanguageRepository = GetDefaultIUserLanguageRepositoryInstance();

            int languageId = 1;
            mockIUserLanguageRepository.Setup(r => r.ListByLanguageIdAsync(languageId)).ReturnsAsync(new List<UserLanguages>());
            int topicId = 1;
            mockIUserTopicRepository.Setup(r => r.ListByTopicId(topicId)).ReturnsAsync(new List<UserTopics>());
            var service = new UserService(mockUserRepository.Object, mockUnitOfWork.Object, mockUserSubscriptionRepository.Object, mockUserScheduleRepository.Object, mockIRoleRepository.Object, mockIUserTopicRepository.Object, mockIUserLanguageRepository.Object);
            //Act
            IEnumerable<User> result = await service.ListTuthorsByLanguageIdAndTopicId(1, 1);
            var count = result.ToList().Count;
            //Assert
            Assert.That(count, Is.EqualTo(0));

        }
        [Test]
        public async Task GetTuthorsAsync_WhenUserHaveTopicAndLanguageAsync_ReturnCollection()
        {
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockUserSubscriptionRepository = GetDefaultIUserSubscriptionRepositoryInstance();
            var mockUserScheduleRepository = GetDefaultIUserScheduleRepositoryInstance();
            var mockIRoleRepository = GetDefaultIRoleRepositoryInstance();
            var mockIUserTopicRepository = GetDefaultIUserTopicRepositoryInstance();
            var mockIUserLanguageRepository = GetDefaultIUserLanguageRepositoryInstance();
            List<UserLanguages> listaUserLanguages = new List<UserLanguages>();
            listaUserLanguages.Add(new UserLanguages() { UserId = 1, LanguageId = 1, User = new User() { RoleId = 2, Id = 1 } });
            listaUserLanguages.Add(new UserLanguages() { UserId = 2, LanguageId = 1, User = new User() { RoleId = 2, Id = 2 } });
            listaUserLanguages.Add(new UserLanguages() { UserId = 3, LanguageId = 1, User = new User() { RoleId = 2, Id = 3 } });
            List<UserTopics> listaUserTopics = new List<UserTopics>();
            listaUserTopics.Add(new UserTopics() { UserId = 1, TopicId = 1, User = new User() { RoleId = 2, Id = 1 } });
            listaUserTopics.Add(new UserTopics() { UserId = 2, TopicId = 1, User = new User() { RoleId = 2, Id = 2 } });
            listaUserTopics.Add(new UserTopics() { UserId = 3, TopicId = 1, User = new User() { RoleId = 2, Id = 3 } });
            int languageId = 1;
            mockIUserLanguageRepository.Setup(r => r.ListByLanguageIdAsync(languageId)).ReturnsAsync(listaUserLanguages);
            int topicId = 1;
            mockIUserTopicRepository.Setup(r => r.ListByTopicId(topicId)).ReturnsAsync(listaUserTopics);

            var service = new UserService(mockUserRepository.Object, mockUnitOfWork.Object, mockUserSubscriptionRepository.Object, mockUserScheduleRepository.Object, mockIRoleRepository.Object, mockIUserTopicRepository.Object, mockIUserLanguageRepository.Object);
            IEnumerable<User> result = await service.ListTuthorsByLanguageIdAndTopicId(1, 1);
            int count = result.ToList().Count;
            Assert.That(count, Is.EqualTo(3));
        }
        [Test]
        public async Task GetUserByRoleId_WhenDoesHaceUserWithRoleId_ReturnEmptyCollection()
        {
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockUserSubscriptionRepository = GetDefaultIUserSubscriptionRepositoryInstance();
            var mockUserScheduleRepository = GetDefaultIUserScheduleRepositoryInstance();
            var mockIRoleRepository = GetDefaultIRoleRepositoryInstance();
            var mockIUserTopicRepository = GetDefaultIUserTopicRepositoryInstance();
            var mockIUserLanguageRepository = GetDefaultIUserLanguageRepositoryInstance();
            var service = new UserService(mockUserRepository.Object, mockUnitOfWork.Object, mockUserSubscriptionRepository.Object, mockUserScheduleRepository.Object, mockIRoleRepository.Object, mockIUserTopicRepository.Object, mockIUserLanguageRepository.Object);
            int roleId = 1;
            mockUserRepository.Setup(r => r.ListUsersByRoleId(roleId)).ReturnsAsync(new List<User>());
            IEnumerable<User> users = await service.ListByRoleId(roleId);
            int usersCount = users.ToList().Count;
            Assert.That(usersCount, Is.EqualTo(0));
        }

        [Test]
        public async Task GetUserByRoleId_WhenHaveUsersWithRoleId_ReturnCollection()
        {
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockUserSubscriptionRepository = GetDefaultIUserSubscriptionRepositoryInstance();
            var mockUserScheduleRepository = GetDefaultIUserScheduleRepositoryInstance();
            var mockIRoleRepository = GetDefaultIRoleRepositoryInstance();
            var mockIUserTopicRepository = GetDefaultIUserTopicRepositoryInstance();
            var mockIUserLanguageRepository = GetDefaultIUserLanguageRepositoryInstance();
            List<User> usersList = new List<User>();
            usersList.Add(new User() { RoleId = 1, Id = 1 });
            usersList.Add(new User() { RoleId = 1, Id = 2 });
            usersList.Add(new User() { RoleId = 1, Id = 3 });
            var service = new UserService(mockUserRepository.Object, mockUnitOfWork.Object, mockUserSubscriptionRepository.Object, mockUserScheduleRepository.Object, mockIRoleRepository.Object, mockIUserTopicRepository.Object, mockIUserLanguageRepository.Object);
            int roleId = 1;
            mockUserRepository.Setup(r => r.ListUsersByRoleId(roleId)).ReturnsAsync(usersList);
            IEnumerable<User> users = await service.ListByRoleId(roleId);
            int usersCount = users.ToList().Count;
            Assert.That(usersCount, Is.EqualTo(3));
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
        }

        private Mock<IRoleRepository> GetDefaultIRoleRepositoryInstance()
        {
            return new Mock<IRoleRepository>();
        }
        private Mock<IUserTopicRepository> GetDefaultIUserTopicRepositoryInstance()
        {
            return new Mock<IUserTopicRepository>();
        }
        private Mock<IUserLanguageRepository> GetDefaultIUserLanguageRepositoryInstance()
        {
            return new Mock<IUserLanguageRepository>();
        }
    }
}