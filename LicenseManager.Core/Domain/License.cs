using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenseManagerCore.Domain
{
    [Table("Licenses", Schema = "app")]
    public class License
    {
        [Key]
        public Guid Id { get; set; }
        public string IP { get; set; }
        public string HWID { get; set; }
        public string Key { get; set; }
        public DateTime ModifyDate { get; set; }
        public Guid? UserId { get; set; } 
        public User User { get; set; }
    }
}