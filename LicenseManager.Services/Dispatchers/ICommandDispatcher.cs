using System.Threading.Tasks;

namespace LicenseManager.Services.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}