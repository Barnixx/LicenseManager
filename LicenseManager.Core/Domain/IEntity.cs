using System;

namespace LicenseManager.Core.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}