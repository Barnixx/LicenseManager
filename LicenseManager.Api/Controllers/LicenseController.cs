using System;
using System.Threading.Tasks;
using LicenseManager.Infrastructure.Mvc;
using LicenseManager.Services.Dispatchers;
using LicenseManager.Services.Licenses;
using LicenseManager.Services.Licenses.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManager.Api.Controllers
{
    
    [Route("api/license/")]
    public class LicenseController : ApiControllerBase
    {
        private readonly ILicenseService _licenseService;
        public LicenseController(ICommandDispatcher commandDispatcher, ILicenseService licenseService) : base(commandDispatcher)
        {
            _licenseService = licenseService;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _licenseService.GetAsync(id), x => x.CustomerId == UserId);

        [HttpPost, Authorize("user")]
        public async Task<IActionResult> Post([FromBody] CreateLicense command)
            => await DispatchAsync(command.BindId(c => c.Id).Bind(c => c.CustomerId, UserId));

    }
}