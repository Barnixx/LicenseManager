using System.Threading.Tasks;

namespace LicenseManager.Services
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}