using System;
using System.ComponentModel.DataAnnotations;

namespace LicenseManager.Core.Domain
{
    public class Entity : IEntity
    {
        [Key]
        public Guid Id { get; protected set; } = Guid.NewGuid();

        protected Entity()
        {
        }

        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}