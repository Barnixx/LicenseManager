using System.Threading.Tasks;

namespace LicenseManager.Core.Types
{
    public interface IAsyncSpecification<in T>
    {
        Task<bool> IsSatisfiedByAsync(T value);
    }
}