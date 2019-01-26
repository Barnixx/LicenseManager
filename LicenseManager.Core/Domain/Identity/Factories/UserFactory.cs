using System;
using System.Threading.Tasks;
using LicenseManager.Core.Domain.Identity.Repositories;
using LicenseManager.Core.Domain.Identity.Services;
using LicenseManager.Core.Domain.Identity.Specifications;

namespace LicenseManager.Core.Domain.Identity.Factories
{
    public class UserFactory : IUserFactory
    {
        private readonly IUserRepository _userRepository;
        private readonly IUniqueEmailSpecification _uniqueEmailSpecification;
        private readonly IUniqueUserNameSpecification _uniqueUserNameSpecification;
        private readonly IHasher _hasher;

        public UserFactory(IUserRepository userRepository,
            IUniqueEmailSpecification uniqueEmailSpecification,
            IUniqueUserNameSpecification uniqueUserNameSpecification,
            IHasher hasher)
        {
            _userRepository = userRepository;
            _uniqueEmailSpecification = uniqueEmailSpecification;
            _uniqueUserNameSpecification = uniqueUserNameSpecification;
            _hasher = hasher;
        }

        public async Task<User> CreateAsync(Guid id, string email, string userName, string password, string role = Role.User)
        {
            var isEmailUnique = await _uniqueEmailSpecification.IsSatisfiedByAsync(email);
            var isUserNameUnique = await _uniqueUserNameSpecification.IsSatisfiedByAsync(userName);
            if (!isEmailUnique)
            {
                throw new DomainException("email_in_use", 
                    $"Email: '{email}' is already in use.");
            }

            if (!isUserNameUnique)
            {
                throw new DomainException("user_in_user",
                    $"UserName: '{userName}' is already in use.");
            }

            if (string.IsNullOrWhiteSpace(role))
            {
                role = Role.User;
            }

            var user = new User(id: id, email: email, userName: userName, role: role);
            user.SetPasswordHash(_hasher.Create(user, password));

            return user;
        }
    }
}