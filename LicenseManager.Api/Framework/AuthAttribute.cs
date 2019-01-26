using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace LicenseManager.Api.Framework
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public AuthAttribute(string policy = "") : base(policy)
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}