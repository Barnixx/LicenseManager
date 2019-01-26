using System;

namespace LicenseManager.Core.Domain.Customers.Events
{
    public class CustomerCreated : IEvent
    {
        public Guid Id { get;  }
        public string FirstName { get; }
        public string LastName { get; }
        

        public CustomerCreated(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}