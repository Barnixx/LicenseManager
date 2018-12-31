using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LicenseManager.Services.Licenses.Commands
{
    public class ChangeStatusLicense : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public string Status { get; }

        [JsonConstructor]
        public ChangeStatusLicense(Guid id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}