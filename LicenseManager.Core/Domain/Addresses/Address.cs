using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenseManager.Core.Domain.Addresses
{
    public class Address : AggregateRoot
    {
        
        public Guid CustomerId { get; protected set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string PostalCode { get; protected set; }
        public DateTime? CreatedAt { get; protected set; }
        public bool Completed => CreatedAt.HasValue;

        protected Address()
        {
        }

        public Address(Guid id, Guid customerId, string city, string street, string postalCode) : base(id)
        {
            CustomerId = customerId;
            City = city;
            Street = street;
            PostalCode = postalCode;
            CreatedAt = DateTime.UtcNow;
        }
        
    }
}