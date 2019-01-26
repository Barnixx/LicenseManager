using System.Threading.Tasks;
using LicenseManager.Core.Domain.Identity.Events;
using LicenseManager.Services.Customers;

namespace LicenseManager.Services.Identity.Handlers
{
    public class SignedUpHandler : IEventHandler<SignedUp>
    {
        private readonly ICustomerService _customerService;

        public SignedUpHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task HandleAsync(SignedUp @event)
            => await _customerService.CreateAsync(@event.UserId, @event.Email);
    }
}