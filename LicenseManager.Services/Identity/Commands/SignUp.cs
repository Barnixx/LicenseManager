using System;
using LicenseManager.Core.Domain;
using Newtonsoft.Json;

namespace LicenseManager.Services.Identity.Commands
{
    public class SignUp : ICommand
    {
        public Guid Id { get; }
        public string Email { get; }
        public string UserName { get; }
        public string Password { get; }
        public string Role { get; }

        [JsonConstructor]
        public SignUp(Guid id, string email, string userName, string password, string role)
        {
            Id = id;
            Email = email;
            UserName = userName;
            Password = password;
            Role = role;
        }
    }
}