using System.Threading.Tasks;
using LicenseManager.Services.Identity.Commands;

namespace LicenseManager.Services.Identity.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IIdentityService _identityService;

        public SignUpHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task HandleAsync(SignUp command)
            => await _identityService.SignUpAsync(command.Id, command.Email, command.UserName, command.Password, command.Role);
    }
}