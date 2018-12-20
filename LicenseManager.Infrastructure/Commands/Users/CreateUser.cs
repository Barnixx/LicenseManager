namespace LicenseManager.Infrastructure.Commands.Users
{
    public class CreateUser : ICommand
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}