using System.Threading.Tasks;
using LicenseManager.Services.Licenses.Commands;

namespace LicenseManager.Services.Licenses.Handlers
{
    public class UpdateLicenseHandler : ICommandHandler<UpdateLicense>
    {
        private readonly ILicenseService _licenseService;

        public UpdateLicenseHandler(ILicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        public async Task HandleAsync(UpdateLicense command)
        {
            var license = await _licenseService.GetAsync(command.Id, command.CustomerId);

            license.Update(command.IP, command.HWID, command.Key);

            await _licenseService.UpdateAsync(license);

        }
    }
}