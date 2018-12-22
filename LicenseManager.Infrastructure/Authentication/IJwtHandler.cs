using System;

namespace LicenseManager.Infrastructure.Authentication
{
    public interface IJwtHandler
    {
        JsonWebToken CreateToken(Guid userId, string role);
        JsonWebTokenPayload GetTokenPayload(string accessToken);
    }
}