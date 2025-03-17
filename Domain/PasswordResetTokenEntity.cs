using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Domain.Entities
{
    [Table("password_reset_tokens")]
    public class PasswordResetTokenEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column("user_id")]
        [ForeignKey("user_id")]
        public UserEntity UserID { get; set; }
        
        [Required]
        [Column("token")]
        public string Token { get; set; }

        [Required]
        [Column("expiration")]
        public DateTime Expiration { get; set; }

        [Column("used")]
        public bool Used { get; set; } = false;
        
    }
}