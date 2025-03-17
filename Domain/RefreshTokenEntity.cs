using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tenant.Domain;

namespace AuthService.Domain.Entities
{
    public class RefreshTokenEntity : CoreEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column("user_id")]
        [ForeignKey("user_id")]
        public UserEntity UserId { get; set; }

        [Required, MaxLength(500)]
        [Column("token")]
        public string Token { get; set; }

        [Column("expires_at")]
        public DateTime ExpiresAt { get; set; }

        [Column("revoked_at")]
        public DateTime? RevokedAt { get; set; }

    }
}