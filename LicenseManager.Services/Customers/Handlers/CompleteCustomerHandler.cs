using System.Threading.Tasks;
using LicenseManager.Services.Customers.Commands;

namespace LicenseManager.Services.Customers.Handlers
{
    public class CreateCustomerHandler : ICommandHandler<CompleteCustomer>
    {

        private readonly ICustomerService _customerService;

        public CreateCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task HandleAsync(CompleteCustomer command)
            => await _customerService.CompleteAsync(command.Id, command.FirstName, command.LastName);
    }
}