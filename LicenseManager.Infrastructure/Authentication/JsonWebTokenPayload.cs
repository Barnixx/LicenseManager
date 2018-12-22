namespace LicenseManager.Infrastructure.Authentication
{
    public class JsonWebTokenPayload
    {
        public string Subject { get; set; }
        public string Role { get; set; }
        public long Expires { get; set; }
    }
}