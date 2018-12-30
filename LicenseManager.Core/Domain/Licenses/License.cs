using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenseManager.Core.Domain.Licenses
{
    [Table("Licenses", Schema = "app")]
    public class License : AggregateRoot
    {
        public Guid UserId { get; protected set; } 
        public string IP { get; protected set; }
        public string HWID { get; protected set; }
        public string Key { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? ModifyDate { get; protected set; }
        public LicenseStatus Status { get; protected set; }

        private License()
        {
        }

        public License(Guid id, Guid userId, string ip, string hwid, string key, DateTime createdAt) : base(id)
        {
            UserId = userId;
            IP = ip;
            HWID = hwid;
            Key = key;
            CreatedAt = createdAt;
            Status = LicenseStatus.Created;
        }

        public void Activate()
        {
            if (Status == LicenseStatus.Active)
            {
                throw new DomainException("License already active.");
            }

            Status = LicenseStatus.Active;
        }

        public void Cancel()
        {
            if (Status == LicenseStatus.Canceled)
            {
                throw new DomainException("License already canceled.");
            }

            Status = LicenseStatus.Canceled;
        }

        public enum LicenseStatus : byte
        {
            Created = 0,
            Active = 1,
            Canceled = 2,
        }
    }
}