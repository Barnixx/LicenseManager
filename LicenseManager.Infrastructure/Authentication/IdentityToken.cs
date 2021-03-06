using System;

namespace LicenseManager.Infrastructure.Authentication
{
    public class IdentityToken : JsonWebToken
    {
        public string RefreshToken { get; set; }
        public string Role { get; set; }
        public Guid UserId { get; set; }
    }
}