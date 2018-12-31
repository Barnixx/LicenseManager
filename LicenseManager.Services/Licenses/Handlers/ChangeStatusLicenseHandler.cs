using System;
using System.Reflection;
using System.Threading.Tasks;
using LicenseManager.Core.Domain;
using LicenseManager.Core.Domain.Licenses;
using LicenseManager.Services.Licenses.Commands;

namespace LicenseManager.Services.Licenses.Handlers
{
    public class ChangeStatusLicenseHandler : ICommandHandler<ChangeStatusLicense>
    {
        private readonly ILicenseService _licenseService;

        public ChangeStatusLicenseHandler(ILicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        public async Task HandleAsync(ChangeStatusLicense command)
        {
            var license = await _licenseService.GetAsync(command.Id, command.CustomerId);
            var methodInfo = typeof(License).GetMethod(command.Status);
            License.LicenseStatus status;
            if (methodInfo == null || !Enum.TryParse(command.Status, out status))
            {
                throw new ServiceException("wrong_status",
                    $"Status: '{command.Status}' is wrong");
            }

            try
            {
                methodInfo.Invoke(license, new object[] { });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                throw e.InnerException;
                
            }
            
            await _licenseService.UpdateAsync(license);

        }
        
    }
}