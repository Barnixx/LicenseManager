using System;
using System.Linq;
using System.Threading.Tasks;
using LicenseManager.Core.Types;
using LicenseManager.Services;
using LicenseManager.Services.Dispatchers;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManager.Api.Controllers
{
    [ApiController]
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

        protected bool isAdmin
            => User.IsInRole("admin");

        protected Guid UserId
            => string.IsNullOrWhiteSpace(User?.Identity?.Name) ? Guid.Empty : Guid.Parse(User.Identity.Name);

        protected IActionResult Single<T>(T model, Func<T, bool> criteria = null)
        {
            if (model == null)
            {
                return NotFound();
            }

            var isValid = criteria == null || criteria(model);
            if (isValid)
            {
                return Ok(model);
            }

            return NotFound();
        }

        protected IActionResult Collection<T>(IPagedResult<T> pagedResult, Func<IPagedResult<T>, bool> criteria = null)
        {
            if (pagedResult == null)
            {
                return NotFound();
            }

            var isValid = criteria == null || criteria(pagedResult);
            if (!isValid)
            {
                return NotFound();
            }

            if (pagedResult.IsEmpty)
            {
                return Ok(Enumerable.Empty<T>());
            }

            return Ok(pagedResult);
        }
        
        
    }
}