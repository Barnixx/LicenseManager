using System;
using System.Threading.Tasks;
using LicenseManager.Infrastructure.Commands;
using LicenseManager.Infrastructure.Commands.Users;
using LicenseManager.Infrastructure.Services;

namespace LicenseManager.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.UserName, command.Email, command.Password);
        }
    }
}