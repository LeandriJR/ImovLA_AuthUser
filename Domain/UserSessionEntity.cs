using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Domain.Entities
{
    [Table("user_sessions")]
    public class UserSessionEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column("user_id")]
        [ForeignKey("UserId")]
        public UserEntity UserID { get; set; }

        [Required]
        [Column("ip_address")]
        public string IpAddress { get; set; }

        [Required]
        [Column("user_agent")]
        public string UserAgent { get; set; }

        [Column("expires_at")]
        public DateTime? ExpiresAt { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

    }
}