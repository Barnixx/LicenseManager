namespace LicenseManager.Infrastructure.Authentication
{
    public class JsonWebToken
    {
        public string AccessToken { get; set; }
        public long Expires { get; set; }
    }
}