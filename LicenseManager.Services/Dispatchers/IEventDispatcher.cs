using System.Threading.Tasks;
using LicenseManager.Core.Domain;

namespace LicenseManager.Services.Dispatchers
{
    public interface IEventDispatcher
    {
        Task DispatchAsync(params IEvent[] events);
    }
}