using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulaCredito.Models
{
    [Table("Users")]
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("user_name")]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Column("full_name")]
        [MaxLength(120)]
        public string FullName { get; set; }

        [Column("password")]
        [MaxLength(130)]
        public string Password { get; set; }

        [Column("refresh_token")]
        [MaxLength(500)]
        public string? RefreshToken { get; set; }

        [Column("refresh_token_expiry_time")]
        public DateTime? RefreshTokenExpiryTime { get; set; }

    }
}
