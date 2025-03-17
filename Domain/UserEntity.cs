using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tenant.Domain;

namespace AuthService.Domain.Entities
{
    public class UserEntity : CoreEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(100)]
        [Column("username")]
        public string UserName { get; set; }

        [Required, MaxLength(150)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }
        
        [Column("is_email_confirmed")]
        public bool IsEmailConfirmed { get; set; } = false;

        [Column("last_login_at")]
        public DateTime? LastLoginAt { get; set; }

        public virtual ICollection<RoleUserEntity> UserRoles { get; set; } = new List<RoleUserEntity>();
        public virtual ICollection<RefreshTokenEntity> RefreshTokens { get; set; } = new List<RefreshTokenEntity>();
    }
}