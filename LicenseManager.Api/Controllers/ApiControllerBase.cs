using System.Threading.Tasks;
using LicenseManager.Services;
using LicenseManager.Services.Dispatchers;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManager.Api.Controllers
{
    public abstract class ApiControllerBase : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected async Task<IActionResult> DispatchAsync<T>(T command) where T : ICommand
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}