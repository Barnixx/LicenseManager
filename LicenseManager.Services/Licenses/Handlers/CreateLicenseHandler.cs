using System.Threading.Tasks;
using LicenseManager.Services.Licenses.Commands;

namespace LicenseManager.Services.Licenses.Handlers
{
    public class CreateLicenseHandler : ICommandHandler<CreateLicense>
    {
        private readonly ILicenseService _licenseService;

        public CreateLicenseHandler(ILicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        public async Task HandleAsync(CreateLicense command)
            => await _licenseService.CreateAsync(command.Id, command.CustomerId, command.IP, command.HWID, command.Key);
    }
}