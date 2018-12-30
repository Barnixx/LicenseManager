using System;

namespace LicenseManager.Core.Domain.Customers
{
    public class Address : IValueObject
    {
        public Guid Id { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string PostalCode { get; protected set; }
        public DateTime? CreatedAt { get; protected set; }

        protected Address()
        {
        }

        public Address(Guid id, Guid customerId, string city, string street, string postalCode, DateTime? createdAt)
        {
            Id = id;
            CustomerId = customerId;
            City = city;
            Street = street;
            PostalCode = postalCode;
            CreatedAt = createdAt;
        }
        
        public static Address Create(Guid id, Guid customerId, string city, string street, string postalCode, DateTime createdAt)
            => new Address(id, customerId, city, street, postalCode, createdAt);
    }
}