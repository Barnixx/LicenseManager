using System;
using Newtonsoft.Json;

namespace LicenseManager.Services.Customers.Commands
{
    public class CompleteCustomer : ICommand
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        
        [JsonConstructor]
        public CompleteCustomer(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }        
    }
}