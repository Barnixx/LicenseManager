using System;

namespace LicenseManager.Core.Domain.Identity.Events
{
    public class SignedIn : IEvent
    {
        public Guid UserId { get; }

        public SignedIn(Guid userId)
        {
            UserId = userId;
        }
    }
}