using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenseManager.Core.Domain.Licenses
{
    [Table("Licenses", Schema = "app")]
    public class License : AggregateRoot
    {
        public Guid CustomerId { get; protected set; } 
        public string IP { get; protected set; }
        public string HWID { get; protected set; }
        public string Key { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? ModifyDate { get; protected set; }
        public LicenseStatus Status { get; protected set; }

        private License()
        {
        }

        public License(Guid id, Guid customerId, string ip, string hwid, string key) : base(id)
        {
            CustomerId = customerId;
            IP = ip;
            HWID = hwid;
            Key = key;
            CreatedAt = DateTime.UtcNow;
            Status = LicenseStatus.Created;
        }

        public void Update(string ip, string hwid, string key)
        {
            IP = ip;
            HWID = hwid;
            Key = key;
            ModifyDate = DateTime.UtcNow;
            Status = LicenseStatus.Updated;
        }

        public void Active()
        {
            if (Status == LicenseStatus.Active)
            {
                throw new DomainException("license_error", "License already active.");
            }

            ModifyDate = DateTime.UtcNow;
            Status = LicenseStatus.Active;
        }

        public void Canceled()
        {
            if (Status == LicenseStatus.Canceled)
            {
                throw new DomainException("license_error", "License already canceled.");
            }
            ModifyDate = DateTime.UtcNow;
            Status = LicenseStatus.Canceled;
        }

        public enum LicenseStatus : byte
        {
            Created = 0,
            Active = 1,
            Canceled = 2,
            Updated = 3,
        }
    }
}