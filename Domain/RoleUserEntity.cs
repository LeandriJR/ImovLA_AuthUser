using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tenant.Domain;

namespace AuthService.Domain.Entities
{
    public class RoleUserEntity : CoreEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [ForeignKey("user_id")]
        [Column("user_id")]
        public UserEntity UserId { get; set; }

        [ForeignKey("role_id")]
        [Column("role_id")]
        public RoleEntity RoleId { get; set; }
    }
}