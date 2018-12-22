using System;
using LicenseManager.Core.Domain.Customers.Events;

namespace LicenseManager.Core.Domain.Customers
{
    public class Customer : AggregateRoot
    {
        public string Email { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public bool Completed => CompletedAt.HasValue;
        public DateTime? CompletedAt { get; protected set; }

        protected Customer()
        {
        }

        public Customer(Guid id, string email) : base(id)
        {
            Email = email;
            CreatedAt = DateTime.UtcNow;
        }

        public void Complete(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            CompletedAt = DateTime.UtcNow;
            AddEvent(new CustomerCreated(Id, firstName, lastName));
        }
    }
}