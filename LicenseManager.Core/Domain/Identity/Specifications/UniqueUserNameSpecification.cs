using System.Threading.Tasks;
using LicenseManager.Core.Domain.Identity.Repositories;

namespace LicenseManager.Core.Domain.Identity.Specifications
{
    public class UniqueUserNameSpecification : IUniqueUserNameSpecification
    {
        private readonly IUserRepository _userRepository;

        public UniqueUserNameSpecification(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> IsSatisfiedByAsync(string value)
            => await _userRepository.IsUserNameUnique(value);
    }
}