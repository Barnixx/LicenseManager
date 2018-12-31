using System;
using Newtonsoft.Json;

namespace LicenseManager.Services.Licenses.Commands
{
    public class CreateLicense : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; } 
        public string IP { get; }
        public string HWID { get; }
        public string Key { get; }

        [JsonConstructor]
        public CreateLicense(Guid id, Guid customerId, string ip, string hwid, string key)
        {
            Id = id;
            CustomerId = customerId;
            IP = ip;
            HWID = hwid;
            Key = key;
        }
    }
}