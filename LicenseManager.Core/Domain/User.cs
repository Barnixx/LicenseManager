using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenseManager.Core.Domain
{
    [Table("Users", Schema = "app")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [Column("Username")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [Column("Email")]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Column("LastLogin")]
        public DateTime LastLogin { get; set; }
        public UserDetails UserDetails { get; set; }
        public ICollection<License> Licenses { get; set; }

        public User(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }
    }
}