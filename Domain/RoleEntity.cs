using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tenant.Domain;

namespace AuthService.Domain.Entities
{
    public class RoleEntity : CoreEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(50)]
        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<RoleUserEntity> UserRoles { get; set; } = new List<RoleUserEntity>();
    }
}