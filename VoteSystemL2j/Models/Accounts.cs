using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoteSystemL2j.Models
{
    [Table("accounts")]
    public class Accounts
    {
        [Key]
        [Column("login")]
        [MaxLength(45, ErrorMessage = "Login cannot be longer than 45 characters.")]
        public string Login { get; set; }
        [Column("password")]
        [MaxLength(45, ErrorMessage = "Password cannot be longer than 45 characters.")]
        public string Password { get; set; }
        [Column("email")]
        public string Email { get; set; }
    }
}
