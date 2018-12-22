using System.Collections.Generic;

namespace LicenseManager.Core.Domain
{
    public interface IAggregateRoot : IEntity
    {
        IEnumerable<IEvent> Events { get; }
    }
}