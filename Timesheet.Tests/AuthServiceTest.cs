using NUnit.Framework;
using Timesheet.Application.Services;
using Timesheet.Domain;

namespace Timesheet.Tests
{
    public class AuthServiceTest
    {
        private readonly IAuthService _authService;
        public AuthServiceTest(IAuthService authService)
        {
            _authService = authService;
        }

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Иванов")]
        [TestCase("Петров")]
        [TestCase("Сидоров")]
        public void Login_ShouldReturnTrue(string lastName)
        {
            //arrange

            //act
            var result = service.Login(lastName);

            //assert
            Assert.IsTrue(result);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("TestUser")]
        public void Login_ShouldReturnFalse(string lastName)
        {
            //arrange
            var service = new AuthService();

            //act
            var result = service.Login(lastName);

            //assert
            Assert.IsFalse(result);
        }
    }
}