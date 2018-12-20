using System.Threading.Tasks;
using LicenseManager.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManager.Api.Controllers
{
    [Route("[controller]")]
    public class ApiControllerBase : Controller
    {
        private ICommandDispatcher _commandDispatcher;

        public ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            await _commandDispatcher.DispatchAsync(command);
        }
    }
}