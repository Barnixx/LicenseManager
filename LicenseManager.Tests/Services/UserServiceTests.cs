using System;
using System.Threading.Tasks;
using FluentAssertions;
using LicenseManager.Core.Domain;
using LicenseManager.Core.Repository;
using LicenseManager.Infrastructure.Services;
using Moq;
using Xunit;

namespace LicenseManager.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task when_calling_get_async_and_user_exists_it_should_return_user()
        {
            var userRepositoryMock = new Mock<IUserRepository>();

            var userService = new UserService(userRepositoryMock.Object);

            var user = new User(Guid.NewGuid(), "user1", "user1@email.com", "secretpassword");

            userRepositoryMock
                .Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(user);

            var userResult = await userService.GetAsync(Guid.NewGuid());

            user.Email.Should().BeEquivalentTo(userResult.Email);
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<Guid>()), Times.Once);
        } 
    }
}