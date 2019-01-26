using System;
using System.Threading.Tasks;
using LicenseManager.Core.Domain.Identity;
using LicenseManager.Core.Domain.Identity.Repositories;

namespace LicenseManager.Infrastructure.EF.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ISqlServerRepository<RefreshToken> _repository;

        public RefreshTokenRepository(ISqlServerRepository<RefreshToken> repository)
        {
            _repository = repository;
        }

        public async Task<RefreshToken> GetAsync(string token)
            => await _repository.GetAsync(x => x.Token == token);

        public async Task<RefreshToken> GetAsync(Guid userId)
            => await _repository.GetAsync(t => t.UserId == userId);
        
        public async Task<bool> UserTokenExists(Guid userId)
            => await _repository.ExistsAsync(t => t.UserId == userId == true);

        public async Task CreateAsync(RefreshToken token)
            => await _repository.CreateAsync(token);

        public async Task UpdateAsync(RefreshToken token)
            => await _repository.UpdateAsync(token);

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);
    }
}