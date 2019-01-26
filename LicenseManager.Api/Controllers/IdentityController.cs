using System.Threading.Tasks;
using LicenseManager.Infrastructure.Mvc;
using LicenseManager.Services.Dispatchers;
using LicenseManager.Services.Identity;
using LicenseManager.Services.Identity.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManager.Api.Controllers
{
    [Route("api/")]
    [AllowAnonymous]
    public class IdentityController : ApiControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IRefreshTokenService _refreshTokenService;
        
        public IdentityController(ICommandDispatcher commandDispatcher, IIdentityService identityService, IRefreshTokenService refreshTokenService) : base(commandDispatcher)
        {
            _identityService = identityService;
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUp command)
            => await DispatchAsync(command.BindId(c => c.Id));

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignIn command)
            => Ok(await _identityService.SignInAsync(command.Email, command.Password));

        [HttpPost("refreshToken/{refreshToken}/refresh")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
            => Ok(await _refreshTokenService.CreateAccessTokenAsync(refreshToken));
    }
}