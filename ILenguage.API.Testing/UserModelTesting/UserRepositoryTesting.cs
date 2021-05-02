using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ILenguage.API.Testing.UserModelTesting
{
    [TestClass]
    public class UserRepositoryTesting
    {
        [TestMethod]
        public void FindUserById_ReturnTaskUser()
        {
            //Arrange
            int userId = 200;
            UserRepository userRepository;
            //Act
            Task<User> result = userRepository.FindById(userId);
            Task<User> expected;
            // Assert
            Assert.AreEqual(expected, result, "Is not valid userId");

        }
    }
}