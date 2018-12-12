using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenseManagerCore.Domain
{
    [Table("UsersDetails", Schema = "app")]
    public class UserDetails
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Column("Surname")]
        public string Surname { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
    }
}