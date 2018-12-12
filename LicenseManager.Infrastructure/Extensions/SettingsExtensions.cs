using Microsoft.Extensions.Configuration;

namespace LicenseManager.Infrastructure.Extensions
{
    public static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : new()
        {
            var section = typeof(T).Name.Replace("Settings", string.Empty); // Get Name of class and remove "Settings" from name
            var configurationValue = new T(); // Create new object of T class
            configuration.GetSection(section).Bind(configurationValue); // Get section from appsettings.json and bind it to configurationValue

            return configurationValue; // return T object
        }
    }
}