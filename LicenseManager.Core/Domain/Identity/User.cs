using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LicenseManager.Core.Domain.Identity.Events;

namespace LicenseManager.Core.Domain.Identity
{
    //Aggregate
    [Table("Users", Schema = "app")]
    public class User : AggregateRoot
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [Column("Username")]
        public string UserName { get; protected set; }
        
        [Required]
        [EmailAddress]
        [Column("Email")]
        public string Email { get; protected set; }
        
        public string Role { get; protected set; }
        
        [Required]
        [MinLength(8)]
        public string PasswordHash { get; protected set; }
        
        [Column("LastLogin")]
        public DateTime? LastLogin { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }

        protected User()
        {
        }
        
        public User(Guid id, string userName, string email, string role) : base(id)
        {
            if (!Identity.Role.IsValid(role))
            {
                throw new DomainException("invalid_role", $"Invalid role: '{role}'.");
            }

            UserName = userName;
            Email = email.ToLowerInvariant();
            Role = role.ToLowerInvariant();
            CreatedAt = DateTime.UtcNow;
            AddEvent(new SignedUp(id, email, role));
        }

        public void Login()
        {
            LastLogin = DateTime.UtcNow;;
        }

        public void SetPasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}