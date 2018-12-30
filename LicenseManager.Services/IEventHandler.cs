using System.Threading.Tasks;
using LicenseManager.Core.Domain;

namespace LicenseManager.Services
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}