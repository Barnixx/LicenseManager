using System;
using LicenseManager.Core.Domain.Licenses;
using Newtonsoft.Json;

namespace LicenseManager.Services.Licenses.DTOs
{
    public class LicenseDto
    {
        public Guid Id { get; set; } 
        [JsonIgnore]
        public Guid CustomerId { get; set; }
        public string IP { get; set; }
        public string HWID { get; set; }
        public string Key { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Status { get; set; }
    }
}