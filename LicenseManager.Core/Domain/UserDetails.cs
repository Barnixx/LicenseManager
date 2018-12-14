using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenseManager.Core.Domain
{
    [Table("UsersDetails", Schema = "app")]
    public class UserDetails
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(80)]
        public string Name { get; set; }
        [Column("Surname")]
        [MaxLength(80)]
        public string Surname { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
    }
}