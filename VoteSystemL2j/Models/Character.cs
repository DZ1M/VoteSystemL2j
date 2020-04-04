using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VoteSystemL2j.Models.Enums;

namespace VoteSystemL2j.Models
{
    [Table("characters")]
    public class Character
    {
        [Key]
        [Column("account_name")]
        public string Login { get; set; }

        [Column("char_name")]
        public string CharName { get; set; }

        [Column("charId")]
        public int CharId { get; set; }

        [Column("online")]
        public Status Online { get; set; }
    }
}
