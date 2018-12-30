using System;
using System.Collections.Generic;
using System.Linq;
using LicenseManager.Core.Domain.Customers.Events;

namespace LicenseManager.Core.Domain.Customers
{
    public class Customer : AggregateRoot
    {
        public string Email { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public bool Completed => CompletedAt.HasValue && _addresses.Count > 0;
        public DateTime? CompletedAt { get; protected set; }
        private ISet<Address> _addresses = new HashSet<Address>();

        public IEnumerable<Address> Addresses
        {
            get => _addresses;
            set => _addresses = new HashSet<Address>(value);
        }

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

        public void AddAddress(Address address)
        {
            var pAddress = GetAddress(address.Id);
            if (pAddress != null)
            {
                _addresses.Remove(pAddress);
            }

            _addresses.Add(address);
        }

        private Address GetAddress(Guid addressId)
        {
            return _addresses.SingleOrDefault(x => x.Id == addressId);
        }
    }
}