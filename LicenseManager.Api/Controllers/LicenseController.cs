using System;
using System.Threading.Tasks;
using LicenseManager.Infrastructure.Mvc;
using LicenseManager.Services.Dispatchers;
using LicenseManager.Services.Licenses;
using LicenseManager.Services.Licenses.Commands;
using LicenseManager.Services.Licenses.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManager.Api.Controllers
{
    [Authorize]
    [Route("api/license/")]
    public class LicenseController : ApiControllerBase
    {
        private readonly ILicenseService _licenseService;
        public LicenseController(ICommandDispatcher commandDispatcher, ILicenseService licenseService) : base(commandDispatcher)
        {
            _licenseService = licenseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseLicenses query)
            => Collection(await _licenseService.BrowseAsync(UserId, query));
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _licenseService.GetAsync(id), x => x.CustomerId == UserId);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLicense command)
            => await DispatchAsync(command.BindId(c => c.Id).Bind(c => c.CustomerId, UserId));

        [HttpPost("change-status")]
        public async Task<IActionResult> Post([FromBody] ChangeStatusLicense command)
            => await DispatchAsync(command.Bind(c => c.CustomerId, UserId));

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateLicense command)
            => await DispatchAsync(command.Bind(c => c.CustomerId, UserId));

    }
}