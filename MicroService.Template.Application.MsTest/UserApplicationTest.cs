using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MicroService.Template.Application.DTO;
using MicroService.Template.Application.Interface;
using MicroService.Template.Transversal.Common.Constants;

namespace MicroService.Template.Application.MsTest
{
    [TestClass]
    public class UserApplicationTest
    {
        private static WebApplicationFactory<Program> _factory;
        private static IServiceScopeFactory _scopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _) {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void Authenticate_WithoutParameters_ErrorsValidation()
        {
            using var scope = _scopeFactory.CreateScope();
            var sut = scope.ServiceProvider.GetService<IUserApplication>();

            //Arrange
            var user = new UserLoginDto {
                UserName = string.Empty,
                Password = string.Empty
            };

            //Act
            var result = sut.Authenticate(user);
            string msg = result.Message;

            //Assert
            result.Should().NotBeNull();
            msg.Should().BeEquivalentTo(Messages.VALIDATION_ERRORS);
        }

        [DataTestMethod]
        [DataRow("Mauve0434", "z$6M9*AfoK6")]
        public void Authenticate_WithParametersOK_UserAuthenticated(string userName,string password)
        {
            using var scope = _scopeFactory.CreateScope();
            var sut = scope.ServiceProvider.GetService<IUserApplication>();

            //Arrange
            var user = new UserLoginDto
            {
                //Change this data with your own user
                UserName = userName,
                Password = password
            };

            //Act
            var result = sut.Authenticate(user);
            string msg = result.Message;

            //Assert
            msg.Should().BeEquivalentTo(Messages.AUTHENTICATED);
        }

        [TestMethod]
        public void Authenticate_WithWrongParameters_UserDoesNotExists()
        {
            using var scope = _scopeFactory.CreateScope();
            var sut = scope.ServiceProvider.GetService<IUserApplication>();

            //Arrange
            var user = new UserLoginDto
            {
                UserName = "Unglazed2060",
                Password = "123456."
            };

            //Act
            var result = sut.Authenticate(user);
            string msg = result.Message;

            //Assert
            msg.Should().BeEquivalentTo( Messages.USER_NOT_EXISTS);
        }
    }
}