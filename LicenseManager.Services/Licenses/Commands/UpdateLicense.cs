using System;
using Newtonsoft.Json;

namespace LicenseManager.Services.Licenses.Commands
{
    public class UpdateLicense : ICommand
    {
        public Guid Id { get; }
        [JsonIgnore]
        public Guid CustomerId { get; } 
        public string IP { get; }
        public string HWID { get; }
        public string Key { get; }

        [JsonConstructor]
        public UpdateLicense(Guid id, string ip, string hwid, string key)
        {
            Id = id;
            IP = ip;
            HWID = hwid;
            Key = key;
        }
    }
}